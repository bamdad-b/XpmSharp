using B2.XpmSharp;
using B2.XpmSharp.Drawing;

namespace B2.XpmTest
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            selectButton.Click += (_, _) =>
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadButton.Enabled = true;
                    loadButton.Click += (_, _) =>
                    {
                        using var stream = openFileDialog.OpenFile();
                        var xpm = XPixMap.FromStream(stream);
                        xpm.DrawOn(Handle);
                    };
                }
            };

            buttonClear.Click += (_, _) =>
            {
                Invalidate();
            };
        }
    }
}
