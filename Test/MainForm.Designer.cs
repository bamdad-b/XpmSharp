namespace B2.XpmTest
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            loadButton = new Button();
            selectButton = new Button();
            openFileDialog = new OpenFileDialog();
            buttonClear = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // loadButton
            // 
            loadButton.Enabled = false;
            loadButton.Location = new Point(3, 32);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(75, 23);
            loadButton.TabIndex = 1;
            loadButton.Text = "Load";
            loadButton.UseVisualStyleBackColor = true;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(3, 3);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(75, 23);
            selectButton.TabIndex = 0;
            selectButton.Text = "Select";
            selectButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog";
            openFileDialog.Filter = "XMP files|*.xpm|All files|*.*";
            // 
            // buttonClear
            // 
            buttonClear.Location = new Point(3, 61);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 23);
            buttonClear.TabIndex = 2;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Right;
            panel1.Location = new Point(279, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(81, 202);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(selectButton);
            panel2.Controls.Add(buttonClear);
            panel2.Controls.Add(loadButton);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 115);
            panel2.Name = "panel2";
            panel2.Size = new Size(81, 87);
            panel2.TabIndex = 4;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DimGray;
            ClientSize = new Size(360, 202);
            Controls.Add(panel1);
            Name = "MainForm";
            Text = "MainForm";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button loadButton;
        private Button selectButton;
        private OpenFileDialog openFileDialog;
        private Button buttonClear;
        private Panel panel1;
        private Panel panel2;
    }
}
