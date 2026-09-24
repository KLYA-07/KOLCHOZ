namespace WinFormsPresentation
{
    partial class ReadDialog
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
            title = new Label();
            farmerName = new Label();
            financialCapital = new Label();
            fieldSize = new Label();
            harvestList = new ListBox();
            label1 = new Label();
            label2 = new Label();
            cattleList = new ListBox();
            label3 = new Label();
            cultureList = new ListBox();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 15F);
            title.Location = new Point(314, 9);
            title.Name = "title";
            title.Size = new Size(360, 41);
            title.TabIndex = 0;
            title.Text = "Информация о фермере";
            // 
            // farmerName
            // 
            farmerName.Location = new Point(266, 65);
            farmerName.Name = "farmerName";
            farmerName.Size = new Size(433, 33);
            farmerName.TabIndex = 1;
            farmerName.Text = "Имя фермера: ";
            farmerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // financialCapital
            // 
            financialCapital.Location = new Point(266, 98);
            financialCapital.Name = "financialCapital";
            financialCapital.Size = new Size(433, 33);
            financialCapital.TabIndex = 2;
            financialCapital.Text = "Финансовый капитал: ";
            financialCapital.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldSize
            // 
            fieldSize.Location = new Point(266, 131);
            fieldSize.Name = "fieldSize";
            fieldSize.Size = new Size(433, 33);
            fieldSize.TabIndex = 3;
            fieldSize.Text = "Размер поля: ";
            fieldSize.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // harvestList
            // 
            harvestList.FormattingEnabled = true;
            harvestList.ItemHeight = 25;
            harvestList.Location = new Point(231, 200);
            harvestList.Name = "harvestList";
            harvestList.SelectionMode = SelectionMode.None;
            harvestList.Size = new Size(514, 154);
            harvestList.TabIndex = 4;
            // 
            // label1
            // 
            label1.Location = new Point(266, 164);
            label1.Name = "label1";
            label1.Size = new Size(433, 33);
            label1.TabIndex = 5;
            label1.Text = "Состав урожая:";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Location = new Point(266, 357);
            label2.Name = "label2";
            label2.Size = new Size(433, 33);
            label2.TabIndex = 7;
            label2.Text = "Набор выращиваемого скота:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cattleList
            // 
            cattleList.FormattingEnabled = true;
            cattleList.ItemHeight = 25;
            cattleList.Location = new Point(231, 393);
            cattleList.Name = "cattleList";
            cattleList.SelectionMode = SelectionMode.None;
            cattleList.Size = new Size(514, 154);
            cattleList.TabIndex = 6;
            // 
            // label3
            // 
            label3.Location = new Point(266, 550);
            label3.Name = "label3";
            label3.Size = new Size(433, 33);
            label3.TabIndex = 9;
            label3.Text = "Набор выращиваемых культур:";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cultureList
            // 
            cultureList.FormattingEnabled = true;
            cultureList.ItemHeight = 25;
            cultureList.Location = new Point(231, 586);
            cultureList.Name = "cultureList";
            cultureList.SelectionMode = SelectionMode.None;
            cultureList.Size = new Size(514, 154);
            cultureList.TabIndex = 8;
            // 
            // ReadDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(968, 812);
            Controls.Add(label3);
            Controls.Add(cultureList);
            Controls.Add(label2);
            Controls.Add(cattleList);
            Controls.Add(label1);
            Controls.Add(harvestList);
            Controls.Add(fieldSize);
            Controls.Add(financialCapital);
            Controls.Add(farmerName);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReadDialog";
            Text = "Информация о фермере";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label farmerName;
        private Label financialCapital;
        private Label fieldSize;
        private ListBox harvestList;
        private Label label1;
        private Label label2;
        private ListBox cattleList;
        private Label label3;
        private ListBox cultureList;
    }
}