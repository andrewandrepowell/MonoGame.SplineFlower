﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.SplineFlower.Content;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MonoGame.SplineFlower
{
    public abstract class SplineWalker
    {
        public enum SplineWalkerMode
        {
            Once = 0,
            Loop = 1,
            PingPong = 2
        }
        public SplineWalkerMode WalkerMode { get; set; }

        public enum SplineWalkerTriggerDirection
        {
            Forward,
            Backward,
            ForwardAndBackward
        }
        private SplineWalkerTriggerDirection TriggerDirection { get; set; }

        public enum SplineWalkerTriggerMode
        {
            Dynamic,
            TriggerByTrigger
        }
        private SplineWalkerTriggerMode TriggerMode { get; set; }

        public enum SplineWalkerInput
        {
            None,
            GamePad,
            Keyboard
        }
        private SplineWalkerInput InputMode { get; set; }

        public enum ResetLocation
        {
            Start,
            End
        }

        protected BezierSpline _Spline;

        protected Vector2 Position { get; private set; }
        protected Vector2 Direction
        {
            get
            {
                Vector2 normalized = _Direction;
                normalized.Normalize();
                return normalized;
            }
            private set { _Direction = value; }
        }
        private Vector2 _Direction;
        public float GetProgress { get; private set; }
        protected float Rotation { get; private set; }
        public int Duration { get; set; }
        private Rectangle _Size = new Rectangle(0, 0, 10, 10);
        private void SetPosition(Vector2 position)
        {
            Position = position;
            _Size.X = (int)position.X;
            _Size.Y = (int)position.Y;
        }
        public Vector2 GetPositionOnCurve(float position)
        {
            return _Spline.GetPoint(position);
        }

        public bool Initialized { get; private set; } = false;
        public Guid LastTriggerID { get; private set; }
        public bool CanTriggerEvents { get; set; } = true;
        public bool TurnWhenWalkingBackwards
        {
            get { return _TurnWhenWalkingBackwards; }
            set { _CheckIfWalkingBackwards = value; }
        }
        private bool _TurnWhenWalkingBackwards = false, _CheckIfWalkingBackwards = false;

        private bool _GoingForward = true;
        private bool _LookForward = true;
        private bool _AutoStart = true;
        private bool _ReachedEndOfSpline = false;
        private bool _SplineDirectionChanged = false;
        private bool _ApproachingNextTrigger = false;
        private bool _ApproachingPreviousTrigger = false;
        private bool _RevolutionApproachForward = false;
        private bool _RevolutionApproachBackward = false;
        public int _CurrentTriggerIndex = 0;

        private Keys _ForwardKey, _BackwardKey;
        private Buttons _ForwardButton, _BackwardButton;
        private KeyboardState _oldKeyboardState;
        private GamePadState _oldGamePadState;

        public virtual void CreateSplineWalker(
            BezierSpline spline, 
            SplineWalkerMode mode,
            int duration,
            bool canTriggerEvents = true,
            SplineWalkerTriggerDirection triggerDirection = SplineWalkerTriggerDirection.Forward,
            bool autoStart = true)
        {
            _Spline = spline;
            _AutoStart = autoStart;
            CanTriggerEvents = canTriggerEvents;
            TriggerDirection = triggerDirection;
            Duration = duration;
            WalkerMode = mode;

            SetPosition(0);
            GetProgress = 0;
            ResetTriggerIndex(false);

            _Spline.EventTriggered += EventTriggered;

            _oldKeyboardState = Keyboard.GetState();
            _oldGamePadState = GamePad.GetState(PlayerIndex.One);

            Initialized = true;
        }

        public void SetInput(Keys forwardKey, Keys backwardKey, SplineWalkerTriggerMode triggerMode)
        {
            InputMode = SplineWalkerInput.Keyboard;
            _AutoStart = false;

            _ForwardKey = forwardKey;
            _BackwardKey = backwardKey;

            SetTriggerMode(triggerMode);
        }
        public void SetInput(Buttons forwardButton, Buttons backwardButton, SplineWalkerTriggerMode triggerMode)
        {
            InputMode = SplineWalkerInput.GamePad;
            _AutoStart = false;

            _ForwardButton = forwardButton;
            _BackwardButton = backwardButton;

            SetTriggerMode(triggerMode);
        }
        public void ResetInput()
        {
            InputMode = SplineWalkerInput.None;
            _AutoStart = true;
            TriggerMode = SplineWalkerTriggerMode.Dynamic;
        }
        private void SetTriggerMode(SplineWalkerTriggerMode triggerMode)
        {
            TriggerMode = triggerMode;

            Trigger firstTrigger = GetTriggers().First();
            if (TriggerMode == SplineWalkerTriggerMode.TriggerByTrigger && firstTrigger != null)
            {
                SetPosition(_Spline.GetPoint(firstTrigger.Progress));
                GetProgress = firstTrigger.Progress;
            }
        }

        public Guid AddTrigger(string name, float progress, int triggerDistance)
        {
            Guid id = _Spline.AddTrigger(name, progress, triggerDistance);
            if (_CurrentTriggerIndex != 0) _CurrentTriggerIndex++;
            return id;
        }
        protected virtual void EventTriggered(Trigger obj)
        {
            if (CanTriggerEvents)
            {
                if (CanTrigger(obj))
                {
                    if (_GoingForward)
                    {
                        if (TriggerMode == SplineWalkerTriggerMode.Dynamic) _CurrentTriggerIndex++;
                        if (_CurrentTriggerIndex > _Spline.GetAllTrigger().Count - 1) ResetTriggerIndex(false);
                    }
                    else
                    {
                        if (TriggerMode == SplineWalkerTriggerMode.Dynamic) _CurrentTriggerIndex--;
                        if (_CurrentTriggerIndex < 0) ResetTriggerIndex(false);
                    }
                }
                LastTriggerID = obj.ID;
            }
        }
        protected bool CanTrigger(Trigger trigger)
        {
            if (LastTriggerID == trigger.ID ||
                (!_GoingForward && TriggerDirection == SplineWalkerTriggerDirection.Forward) ||
                (_GoingForward && TriggerDirection == SplineWalkerTriggerDirection.Backward)) return false;
            else return true;
        }

        private void ResetTriggerIndex(bool revolution)
        {
            LastTriggerID = new Guid();

            if (!_ReachedEndOfSpline && !revolution)
            {
                if (TriggerMode == SplineWalkerTriggerMode.Dynamic)
                {
                    if (_GoingForward &&
                        (TriggerDirection == SplineWalkerTriggerDirection.Forward || TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward))
                    {
                        _CurrentTriggerIndex = 0;
                    }
                    else if (TriggerDirection == SplineWalkerTriggerDirection.Backward || TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward)
                    {
                        _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
                    }
                }
                else _CurrentTriggerIndex = 0;
            }
            else if (WalkerMode == SplineWalkerMode.PingPong || InputMode != SplineWalkerInput.None) SetTriggerIndex();
            else if (GetProgress >= 1 && InputMode == SplineWalkerInput.None) _CurrentTriggerIndex = 0;

            if (_ReachedEndOfSpline) GetTriggers().ForEach(x => x.Triggered = false);
        }
        private void SetTriggerIndex()
        {
            if (TriggerMode == SplineWalkerTriggerMode.Dynamic)
            {
                if (GetProgress >= 1 && TriggerDirection == SplineWalkerTriggerDirection.Forward) _CurrentTriggerIndex = -1;
                if (GetProgress >= 1 && TriggerDirection == SplineWalkerTriggerDirection.Backward) _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
                if (GetProgress >= 1 && TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward) _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
                if (GetProgress <= 0 && TriggerDirection == SplineWalkerTriggerDirection.Forward) _CurrentTriggerIndex = 0;
                if (GetProgress <= 0 && TriggerDirection == SplineWalkerTriggerDirection.Backward) _CurrentTriggerIndex = -1;
                if (GetProgress <= 0 && TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward) _CurrentTriggerIndex = 0;
            }
            else if (TriggerMode == SplineWalkerTriggerMode.TriggerByTrigger)
            {
                if (WalkerMode != SplineWalkerMode.Once)
                {
                    if (!_RevolutionApproachBackward)
                    {
                        if (GetProgress >= GetTrigger(GetTriggers().Count - 1).Progress)
                        {
                            _CurrentTriggerIndex = 0;
                            _RevolutionApproachForward = true;
                            _ApproachingNextTrigger = true;

                            return;
                        }
                        else
                        {
                            if (_RevolutionApproachForward)
                            {
                                _RevolutionApproachForward = false;
                                return;
                            }
                            if (_RevolutionApproachBackward) return;
                        }
                    }

                    if (!_RevolutionApproachForward)
                    {
                        if (GetProgress <= GetTrigger(GetTriggers().Count - 1).Progress)
                        {
                            _CurrentTriggerIndex = GetTriggers().Count - 1;
                            _RevolutionApproachBackward = true;
                            _ApproachingPreviousTrigger = true;

                            return;
                        }
                        else
                        {
                            _RevolutionApproachBackward = false;
                            if (_RevolutionApproachForward) return;
                        }
                    }
                }
            }
        }

        public virtual void SetPosition(float progress)
        {
            GetProgress = progress;
        }

        public void SetTriggerPosition(string triggerID, float progress)
        {
            _Spline.GetAllTrigger().Find(x => x.ID.ToString() == triggerID).Progress = progress;
        }

        public virtual Trigger GetTrigger(string triggerID = "SelectedTrigger")
        {
            return _Spline.GetAllTrigger().Find(x => x.ID.ToString() == triggerID);
        }

        public virtual Trigger GetTrigger(int index)
        {
            if (index > -1 && index <= _Spline.GetAllTrigger().Count - 1)
            {
                Trigger[] sortedTrigger = _Spline.GetAllTrigger().OrderBy(x => x.Progress).ToArray();

                return sortedTrigger[index];
            }
            return null;
        }

        public List<Trigger> GetTriggers(string name = "")
        {
            if (string.IsNullOrEmpty(name)) return _Spline.GetAllTrigger();
            else return _Spline.GetAllTrigger().FindAll(x => x.Name == name);
        }

        public virtual void Reset(ResetLocation resetLocation = ResetLocation.Start)
        {
            LastTriggerID = new Guid();
            GetProgress = resetLocation == ResetLocation.Start ? 0f : 1f;
            _CurrentTriggerIndex = 0;
        }
        
        public virtual void Update(GameTime gameTime)
        {
            if (GetProgress == 0f || GetProgress == 1f) _ReachedEndOfSpline = true;
            else _ReachedEndOfSpline = false;

            if (_AutoStart)
            {
                if (_GoingForward)
                {
                    GetProgress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (GetProgress > 1f)
                    {
                        ResetTriggerIndex(true);

                        if (WalkerMode == SplineWalkerMode.Once)
                        {
                            GetProgress = 1f;
                        }
                        else if (WalkerMode == SplineWalkerMode.Loop)
                        {
                            GetProgress -= 1f;
                        }
                        else
                        {
                            GetProgress = 2f - GetProgress;
                            _GoingForward = false;
                            if (_CheckIfWalkingBackwards) _TurnWhenWalkingBackwards = true;
                        }
                    }
                }
                else
                {
                    GetProgress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;
                    if (GetProgress < 0f)
                    {
                        ResetTriggerIndex(true);

                        GetProgress = -GetProgress;
                        _GoingForward = true;
                        if (_CheckIfWalkingBackwards) _TurnWhenWalkingBackwards = false;
                    }
                }
            }
            else if (InputMode == SplineWalkerInput.Keyboard)
            {
                if (Keyboard.GetState().IsKeyDown(_ForwardKey) && TriggerMode == SplineWalkerTriggerMode.Dynamic)
                {
                    UpdateForwardMovement(gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(_BackwardKey) && TriggerMode == SplineWalkerTriggerMode.Dynamic)
                {
                    UpdateBackwardMovement(gameTime);
                }
                else if (Keyboard.GetState().IsKeyDown(_ForwardKey) && _oldKeyboardState.IsKeyUp(_ForwardKey) &&
                        TriggerMode == SplineWalkerTriggerMode.TriggerByTrigger)
                {
                    if (_CurrentTriggerIndex == GetTriggers().Count - 1 && WalkerMode == SplineWalkerMode.Once) return;

                    Trigger trigger = GetTrigger(GetNextHigherTriggerIndex());
                    if (GetProgress < trigger.Progress - trigger.TriggerRange)
                    {
                        _ApproachingNextTrigger = true;
                        _ApproachingPreviousTrigger = false;
                    }

                    if (GetProgress >= GetTrigger(_CurrentTriggerIndex).Progress)
                    {
                        if (_CurrentTriggerIndex + 1 <= GetTriggers().Count - 1) _CurrentTriggerIndex++;
                        else ResetTriggerIndex(true);
                    }
                }
                else if (Keyboard.GetState().IsKeyDown(_BackwardKey) && _oldKeyboardState.IsKeyUp(_BackwardKey) &&
                        TriggerMode == SplineWalkerTriggerMode.TriggerByTrigger)
                {
                    if (_CurrentTriggerIndex == 0 && WalkerMode == SplineWalkerMode.Once) return;

                    Trigger trigger = GetTrigger(GetNextLowerTriggerIndex());
                    if (GetProgress >= trigger.Progress + trigger.TriggerRange)
                    {
                        _ApproachingPreviousTrigger = true;
                        _ApproachingNextTrigger = false;
                    }

                    if (_CurrentTriggerIndex - 1 > -1)
                    {
                        if (GetProgress >= GetTrigger(_CurrentTriggerIndex - 1).Progress) _CurrentTriggerIndex--;
                    }
                    else ResetTriggerIndex(true);
                }
            }
            else if (InputMode == SplineWalkerInput.GamePad)
            {
                if (GamePad.GetState(PlayerIndex.One).IsButtonDown(_ForwardButton)) UpdateForwardMovement(gameTime);
                else if (GamePad.GetState(PlayerIndex.One).IsButtonDown(_BackwardButton)) UpdateBackwardMovement(gameTime);
            }

            if (_ApproachingNextTrigger)
            {
                if (GetProgress < GetTrigger(_CurrentTriggerIndex).Progress + (_CurrentTriggerIndex == GetTriggers().Count - 1 && WalkerMode == SplineWalkerMode.Once ? -0.003f : + 0.003f) ||
                    (GetProgress > GetTrigger(_CurrentTriggerIndex).Progress + 0.003f && _RevolutionApproachForward)) UpdateForwardMovement(gameTime, true);
                else _ApproachingNextTrigger = false;
            }
            else if (_ApproachingPreviousTrigger)
            {
                if (GetProgress > GetTrigger(_CurrentTriggerIndex).Progress + 0.003f ||
                    (GetProgress < GetTrigger(_CurrentTriggerIndex).Progress + 0.003f && _RevolutionApproachBackward)) UpdateBackwardMovement(gameTime, true);
                else _ApproachingPreviousTrigger = false;
            }

           if (_LookForward)
            {
                _Direction = _Spline.GetDirection(GetProgress);
                Rotation = (float)Math.Atan2(_Direction.X, -_Direction.Y) - (_TurnWhenWalkingBackwards ? MathHelper.ToRadians(180) : 0);
            }

            SetPosition(_Spline.GetPoint(GetProgress));

            if (CanTriggerEvents &&
                _Spline.GetAllTrigger().Count > 0 &&
                _CurrentTriggerIndex > -1) _Spline.GetAllTrigger()[_CurrentTriggerIndex].CheckIfTriggered(GetProgress);

            _oldGamePadState = GamePad.GetState(PlayerIndex.One);
            _oldKeyboardState = Keyboard.GetState();
        }
        private void UpdateForwardMovement(GameTime gameTime, bool lockTriggerIndex = false)
        {
            if (GetProgress >= 1f)
            {
                if (WalkerMode == SplineWalkerMode.Once) GetProgress = 1f;
                else GetProgress = 0f;

                ResetTriggerIndex(true);
            }
            else
            {
                GetProgress += (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;

                if (_GoingForward == false) InputDirectionChanged(false, lockTriggerIndex);
                _GoingForward = true;
            }
        }
        private void UpdateBackwardMovement(GameTime gameTime, bool lockTriggerIndex = false)
        {
            if (GetProgress <= 0f)
            {
                if (WalkerMode == SplineWalkerMode.Once) GetProgress = 0f;
                else GetProgress = 1f;

                ResetTriggerIndex(true);
            }
            else
            {
                GetProgress -= (float)gameTime.ElapsedGameTime.TotalSeconds / Duration;

                if (_GoingForward == true) InputDirectionChanged(true, lockTriggerIndex);
                _GoingForward = false;
            }
        }
        private void InputDirectionChanged(bool forwardToBackward, bool lockTriggerIndex = false)
        {
            if (!_ReachedEndOfSpline)
            {
                if (TriggerDirection == SplineWalkerTriggerDirection.ForwardAndBackward)
                {
                    LastTriggerID = new Guid();

                    if (forwardToBackward)
                    {
                        if (_CurrentTriggerIndex > -1f)
                        {
                            if (!lockTriggerIndex) _CurrentTriggerIndex--;
                            Trigger lastTrigger = _Spline.GetAllTrigger().Last();
                            if (GetProgress > lastTrigger.Progress) _CurrentTriggerIndex = _Spline.GetAllTrigger().Count - 1;
                        }
                    }
                    else if (!lockTriggerIndex) _CurrentTriggerIndex++;

                    if (_CurrentTriggerIndex > _Spline.GetAllTrigger().Count - 1)
                    {
                        if (GetTriggers().TrueForAll(x => x.Triggered))
                        {
                            Trigger firstTrigger = _Spline.GetAllTrigger().First();
                            if (GetProgress < firstTrigger.Progress) _CurrentTriggerIndex = 0;
                            else
                            {
                                if (!lockTriggerIndex) _CurrentTriggerIndex = -1;
                                GetTriggers().ForEach(x => x.Triggered = false);
                            }
                        }
                        else if (!lockTriggerIndex) _CurrentTriggerIndex--;
                    }
                } 
            }
        }
        private int GetNextLowerTriggerIndex()
        {
            int triggerIndex = 0;
            if (_CurrentTriggerIndex - 1 > -1) triggerIndex = _CurrentTriggerIndex - 1;

            return triggerIndex;
        }
        private int GetNextHigherTriggerIndex()
        {
            int triggerIndex = GetTriggers().Count - 1;
            if (_CurrentTriggerIndex + 1 < triggerIndex) triggerIndex = _CurrentTriggerIndex + 1;

            return triggerIndex;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (Setup.ShowBezierSpline && Setup.ShowSplineWalker)
            {
                spriteBatch.Draw(Setup.Pixel,
                                 _Size,
                                 null,
                                 Color.White,
                                 Rotation,
                                 new Vector2(0.5f),
                                 SpriteEffects.None,
                                 0f);
            }
        }
    }
}
