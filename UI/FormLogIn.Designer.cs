namespace UI
{
    partial class FormLogIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            txt_Usuario = new TextBox();
            txt_Contrasena = new TextBox();
            btn_LogIn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 56);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 0;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 82);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contrasena";
            // 
            // txt_Usuario
            // 
            txt_Usuario.Location = new Point(115, 48);
            txt_Usuario.Name = "txt_Usuario";
            txt_Usuario.Size = new Size(119, 23);
            txt_Usuario.TabIndex = 2;
            txt_Usuario.UseSystemPasswordChar = true;
            // 
            // txt_Contrasena
            // 
            txt_Contrasena.Location = new Point(115, 82);
            txt_Contrasena.Name = "txt_Contrasena";
            txt_Contrasena.Size = new Size(119, 23);
            txt_Contrasena.TabIndex = 3;
            // 
            // btn_LogIn
            // 
            btn_LogIn.Location = new Point(111, 143);
            btn_LogIn.Name = "btn_LogIn";
            btn_LogIn.Size = new Size(123, 23);
            btn_LogIn.TabIndex = 4;
            btn_LogIn.Text = "Log in";
            btn_LogIn.UseVisualStyleBackColor = true;
            btn_LogIn.Click += btn_LogIn_Click;
            // 
            // FormLogIn
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(295, 201);
            Controls.Add(btn_LogIn);
            Controls.Add(txt_Contrasena);
            Controls.Add(txt_Usuario);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogIn";
            Text = "FormLogIn";
            Load += FormLogIn_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txt_Usuario;
        private TextBox txt_Contrasena;
        private Button btn_LogIn;
    }
}