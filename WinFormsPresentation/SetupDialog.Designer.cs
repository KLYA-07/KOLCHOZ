namespace WinFormsPresentation
{
    partial class SetupDialog
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
            farmerName = new TextBox();
            setupTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            financialCapital = new TextBox();
            label3 = new Label();
            fieldSize = new TextBox();
            saveFarmer = new Button();
            label4 = new Label();
            farmAddress = new TextBox();
            label5 = new Label();
            farmerSurname = new TextBox();
            label6 = new Label();
            phoneNumber = new TextBox();
            label7 = new Label();
            farmType = new ComboBox();
            registrationDate = new DateTimePicker();
            label8 = new Label();
            SuspendLayout();
            // 
            // farmerName
            // 
            farmerName.Location = new Point(273, 87);
            farmerName.Name = "farmerName";
            farmerName.Size = new Size(240, 31);
            farmerName.TabIndex = 0;
            farmerName.KeyDown += LeaveEditingOnEnter;
            farmerName.Validating += farmerName_Validating;
            // 
            // setupTitle
            // 
            setupTitle.AutoSize = true;
            setupTitle.Font = new Font("Segoe UI", 15F);
            setupTitle.Location = new Point(148, 9);
            setupTitle.Name = "setupTitle";
            setupTitle.Size = new Size(293, 41);
            setupTitle.TabIndex = 1;
            setupTitle.Text = "Настроить фермера";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 90);
            label1.Name = "label1";
            label1.Size = new Size(126, 25);
            label1.TabIndex = 2;
            label1.Text = "Имя фермера";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 201);
            label2.Name = "label2";
            label2.Size = new Size(184, 25);
            label2.TabIndex = 4;
            label2.Text = "Финансовый капитал";
            // 
            // financialCapital
            // 
            financialCapital.Location = new Point(273, 198);
            financialCapital.Name = "financialCapital";
            financialCapital.Size = new Size(240, 31);
            financialCapital.TabIndex = 3;
            financialCapital.KeyDown += LeaveEditingOnEnter;
            financialCapital.Validating += financialCapital_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 238);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 6;
            label3.Text = "Размер поля";
            // 
            // fieldSize
            // 
            fieldSize.Location = new Point(273, 235);
            fieldSize.Name = "fieldSize";
            fieldSize.Size = new Size(240, 31);
            fieldSize.TabIndex = 5;
            fieldSize.KeyDown += LeaveEditingOnEnter;
            fieldSize.Validating += fieldSize_Validating;
            // 
            // saveFarmer
            // 
            saveFarmer.Location = new Point(171, 448);
            saveFarmer.Name = "saveFarmer";
            saveFarmer.Size = new Size(222, 34);
            saveFarmer.TabIndex = 39;
            saveFarmer.Text = "Сохранить фермера";
            saveFarmer.UseVisualStyleBackColor = true;
            saveFarmer.Click += saveFarmer_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 275);
            label4.Name = "label4";
            label4.Size = new Size(125, 25);
            label4.TabIndex = 41;
            label4.Text = "Адрес фермы";
            // 
            // farmAddress
            // 
            farmAddress.Location = new Point(273, 272);
            farmAddress.Name = "farmAddress";
            farmAddress.Size = new Size(240, 31);
            farmAddress.TabIndex = 40;
            farmAddress.Validating += farmerAddress_Validating;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 127);
            label5.Name = "label5";
            label5.Size = new Size(164, 25);
            label5.TabIndex = 43;
            label5.Text = "Фамилия фермера";
            // 
            // farmerSurname
            // 
            farmerSurname.Location = new Point(273, 124);
            farmerSurname.Name = "farmerSurname";
            farmerSurname.Size = new Size(240, 31);
            farmerSurname.TabIndex = 42;
            farmerSurname.Validating += farmerSurname_Validating;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 164);
            label6.Name = "label6";
            label6.Size = new Size(150, 25);
            label6.TabIndex = 45;
            label6.Text = "Номер телефона";
            // 
            // phoneNumber
            // 
            phoneNumber.Location = new Point(273, 161);
            phoneNumber.Name = "phoneNumber";
            phoneNumber.Size = new Size(240, 31);
            phoneNumber.TabIndex = 44;
            phoneNumber.Validating += phoneNumber_Validating;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(27, 312);
            label7.Name = "label7";
            label7.Size = new Size(104, 25);
            label7.TabIndex = 47;
            label7.Text = "Тип фермы";
            // 
            // farmType
            // 
            farmType.DropDownStyle = ComboBoxStyle.DropDownList;
            farmType.FormattingEnabled = true;
            farmType.Items.AddRange(new object[] { "Растениеводство", "Скотоводство", "Пчеловодство", "Смешанный" });
            farmType.Location = new Point(273, 309);
            farmType.Name = "farmType";
            farmType.Size = new Size(240, 33);
            farmType.TabIndex = 48;
            farmType.Validating += farmType_Validating;
            // 
            // registrationDate
            // 
            registrationDate.Location = new Point(273, 348);
            registrationDate.Name = "registrationDate";
            registrationDate.Size = new Size(240, 31);
            registrationDate.TabIndex = 49;
            registrationDate.Validating += registrationDate_Validating;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(27, 348);
            label8.Name = "label8";
            label8.Size = new Size(157, 25);
            label8.TabIndex = 50;
            label8.Text = "Дата регистрации";
            // 
            // SetupDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(614, 529);
            Controls.Add(label8);
            Controls.Add(registrationDate);
            Controls.Add(farmType);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(phoneNumber);
            Controls.Add(label5);
            Controls.Add(farmerSurname);
            Controls.Add(label4);
            Controls.Add(farmAddress);
            Controls.Add(saveFarmer);
            Controls.Add(label3);
            Controls.Add(fieldSize);
            Controls.Add(label2);
            Controls.Add(financialCapital);
            Controls.Add(label1);
            Controls.Add(setupTitle);
            Controls.Add(farmerName);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "SetupDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Настройка фермера";
            Load += SetupDialog_Load;
            MouseClick += LeaveEditingOnMouseClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox farmerName;
        private Label setupTitle;
        private Label label1;
        private Label label2;
        private TextBox financialCapital;
        private Label label3;
        private TextBox fieldSize;
        private Button saveFarmer;
        private Label label4;
        private TextBox farmAddress;
        private Label label5;
        private TextBox farmerSurname;
        private Label label6;
        private TextBox phoneNumber;
        private Label label7;
        private ComboBox farmType;
        private DateTimePicker registrationDate;
        private Label label8;
    }
}