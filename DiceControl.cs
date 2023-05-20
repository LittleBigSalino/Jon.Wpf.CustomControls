
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;

namespace Jon.Wpf.CustomControls
{
    public class DiceControl : Control
    {
        public Model3DGroup Model { get; private set; }
        static DiceControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(DiceControl), new FrameworkPropertyMetadata(typeof(DiceControl)));
        }
        public DiceControl()
        {
            //var reader = new ObjReader();
            //var model = reader.Read("singledice.obj");
            //var rotation = new AxisAngleRotation3D(new Vector3D(0, 1, 0), 0);
            //var transform = new RotateTransform3D(rotation);
            //model.Transform = transform;

            //this.Model = model;
        }
    }

}