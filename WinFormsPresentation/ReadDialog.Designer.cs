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
            fieldArea = new Label();
            farmerSurname = new Label();
            phoneNumber = new Label();
            farmAddress = new Label();
            farmType = new Label();
            registrationDate = new Label();
            SuspendLayout();
            // 
            // title
            // 
            title.AutoSize = true;
            title.Font = new Font("Segoe UI", 15F);
            title.Location = new Point(171, 9);
            title.Name = "title";
            title.Size = new Size(360, 41);
            title.TabIndex = 0;
            title.Text = "Информация о фермере";
            // 
            // farmerName
            // 
            farmerName.Location = new Point(123, 65);
            farmerName.Name = "farmerName";
            farmerName.Size = new Size(433, 33);
            farmerName.TabIndex = 1;
            farmerName.Text = "Имя фермера: ";
            farmerName.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // financialCapital
            // 
            financialCapital.Location = new Point(123, 164);
            financialCapital.Name = "financialCapital";
            financialCapital.Size = new Size(433, 33);
            financialCapital.TabIndex = 2;
            financialCapital.Text = "Финансовый капитал: ";
            financialCapital.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fieldArea
            // 
            fieldArea.Location = new Point(123, 197);
            fieldArea.Name = "fieldArea";
            fieldArea.Size = new Size(433, 33);
            fieldArea.TabIndex = 3;
            fieldArea.Text = "Площадь поля: ";
            fieldArea.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // farmerSurname
            // 
            farmerSurname.Location = new Point(123, 98);
            farmerSurname.Name = "farmerSurname";
            farmerSurname.Size = new Size(433, 33);
            farmerSurname.TabIndex = 6;
            farmerSurname.Text = "Фамилия фермера: ";
            farmerSurname.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // phoneNumber
            // 
            phoneNumber.Location = new Point(123, 131);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(433, 33);
            phoneNumber.TabIndex = 7;
            phoneNumber.Text = "Номер телефона: ";
            phoneNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // farmAddress
            // 
            farmAddress.Location = new Point(123, 230);
            farmAddress.Name = "farmAddress";
            farmAddress.Size = new Size(433, 33);
            farmAddress.TabIndex = 8;
            farmAddress.Text = "Адрес фермы: ";
            farmAddress.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // farmType
            // 
            farmType.Location = new Point(123, 263);
            farmType.Name = "farmType";
            farmType.Size = new Size(433, 33);
            farmType.TabIndex = 9;
            farmType.Text = "Тип фермы: ";
            farmType.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // registrationDate
            // 
            registrationDate.Location = new Point(123, 296);
            registrationDate.Name = "registrationDate";
            registrationDate.Size = new Size(433, 33);
            registrationDate.TabIndex = 10;
            registrationDate.Text = "Дата регистрации: ";
            registrationDate.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // ReadDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(711, 812);
            Controls.Add(registrationDate);
            Controls.Add(farmType);
            Controls.Add(farmAddress);
            Controls.Add(phoneNumber);
            Controls.Add(farmerSurname);
            Controls.Add(fieldArea);
            Controls.Add(financialCapital);
            Controls.Add(farmerName);
            Controls.Add(title);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "ReadDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Информация о фермере";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label title;
        private Label farmerName;
        private Label financialCapital;
        private Label fieldArea;
        private Label farmerSurname;
        private Label phoneNumber;
        private Label farmAddress;
        private Label farmType;
        private Label registrationDate;
    }
}