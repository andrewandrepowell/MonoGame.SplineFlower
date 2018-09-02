﻿using Microsoft.Xna.Framework;
using MonoGame.SplineFlower.Content;
using System.Windows.Forms;

namespace MonoGame.SplineFlower.Samples.Controls
{
    public class AdvancedControls : TransformControl
    {
        public BezierSpline MySpline;
        public Car MySplineWalker;

        protected override void Initialize()
        {
            base.Initialize();
            Setup.Initialize(Editor.graphics);

            MySpline = new BezierSpline();
            MySpline = Editor.Content.Load<BezierSpline>(@"SplineTrack");
            TryGetTransformFromPosition = MySpline.TryGetTransformFromPosition;
            TryGetTriggerFromPosition = MySpline.TryGetTriggerFromPosition;
            GetAllPoints = MySpline.GetAllPoints;
            RecalculateBezierCenter += SplineControl_RecalculateBezierCenter; ;
            MovePointDiff += SplineEditor_MovePointDiff;

            MySplineWalker = new Car();
            MySplineWalker.CreateSplineWalker(MySpline, SplineWalker.SplineWalkerMode.Once, 7, autoStart: false);
            MySplineWalker.LoadContent(Editor.Content, Editor.Font);

            MoveSplineToScreenCenter();

            SetMultiSampleCount(8);
        }

        public void SplineControl_RecalculateBezierCenter()
        {
            if (MySpline != null) MySpline.CalculateBezierCenter(MySpline.GetAllPoints());
        }

        public void MoveSplineToScreenCenter()
        {
            if (MySpline != null) TranslateAllPointsToScreenCenter(MySpline.GetBezierCenter);
        }

        private void SplineEditor_MovePointDiff(Vector2 obj)
        {
            MySpline.MoveAxis(SelectedTransform.Index, obj);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                SelectedTransform = TryGetTransformFromPosition(new Vector2(e.X, e.Y));
                if (SelectedTransform != null)
                {
                    BezierSpline.BezierControlPointMode nextMode = MySpline.GetControlPointMode(SelectedTransform.Index).Next();
                    MySpline.SetControlPointMode(SelectedTransform.Index, nextMode);
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (SelectedTransform != null) MySpline.EnforceMode(SelectedTransform.Index);
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            if (Editor != null)
            {
                Editor.BeginAntialising();

                Editor.spriteBatch.Begin();

                if (MySpline != null) MySpline.DrawSpline(Editor.spriteBatch);
                if (MySplineWalker != null && MySplineWalker.Initialized) MySplineWalker.Draw(Editor.spriteBatch);
                
                Editor.spriteBatch.DrawString(Editor.Font, "Walker: " + MySplineWalker.Progress.ToString(), new Vector2(10, 30), Color.White);

                Editor.spriteBatch.End();

                Editor.EndAntialising();
            }
        }
    }
}