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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            addProduct = new Button();
            removeProduct = new Button();
            productName = new TextBox();
            productCount = new TextBox();
            productCost = new TextBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label12 = new Label();
            cattleName = new TextBox();
            removeCattle = new Button();
            addCattle = new Button();
            cattleList = new ListBox();
            label13 = new Label();
            cultureName = new TextBox();
            removeCulture = new Button();
            addCulture = new Button();
            cultureList = new ListBox();
            harvestList = new ListBox();
            saveFarmer = new Button();
            SuspendLayout();
            // 
            // farmerName
            // 
            farmerName.Location = new Point(273, 87);
            farmerName.Name = "farmerName";
            farmerName.Size = new Size(240, 31);
            farmerName.TabIndex = 0;
            farmerName.Validating += farmerName_Validating;
            // 
            // setupTitle
            // 
            setupTitle.AutoSize = true;
            setupTitle.Font = new Font("Segoe UI", 15F);
            setupTitle.Location = new Point(273, 9);
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
            label2.Location = new Point(27, 127);
            label2.Name = "label2";
            label2.Size = new Size(184, 25);
            label2.TabIndex = 4;
            label2.Text = "Финансовый капитал";
            // 
            // financialCapital
            // 
            financialCapital.Location = new Point(273, 124);
            financialCapital.Name = "financialCapital";
            financialCapital.Size = new Size(240, 31);
            financialCapital.TabIndex = 3;
            financialCapital.Validating += financialCapital_Validating;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 164);
            label3.Name = "label3";
            label3.Size = new Size(116, 25);
            label3.TabIndex = 6;
            label3.Text = "Размер поля";
            // 
            // fieldSize
            // 
            fieldSize.Location = new Point(273, 161);
            fieldSize.Name = "fieldSize";
            fieldSize.Size = new Size(240, 31);
            fieldSize.TabIndex = 5;
            fieldSize.Validating += fieldSize_Validating;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(27, 201);
            label4.Name = "label4";
            label4.Size = new Size(76, 25);
            label4.TabIndex = 8;
            label4.Text = "Урожай";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(27, 396);
            label5.Name = "label5";
            label5.Size = new Size(151, 25);
            label5.TabIndex = 11;
            label5.Text = "Поголовье скота";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(27, 521);
            label6.Name = "label6";
            label6.Size = new Size(216, 25);
            label6.TabIndex = 13;
            label6.Text = "Выращиваемая культура";
            // 
            // addProduct
            // 
            addProduct.Location = new Point(546, 196);
            addProduct.Name = "addProduct";
            addProduct.Size = new Size(306, 34);
            addProduct.TabIndex = 15;
            addProduct.Text = "Добавить";
            addProduct.UseVisualStyleBackColor = true;
            addProduct.Click += addProduct_Click;
            // 
            // removeProduct
            // 
            removeProduct.Location = new Point(546, 236);
            removeProduct.Name = "removeProduct";
            removeProduct.Size = new Size(306, 34);
            removeProduct.TabIndex = 16;
            removeProduct.Text = "Удалить";
            removeProduct.UseVisualStyleBackColor = true;
            removeProduct.Click += removeProduct_Click;
            // 
            // productName
            // 
            productName.Location = new Point(702, 276);
            productName.Name = "productName";
            productName.Size = new Size(150, 31);
            productName.TabIndex = 17;
            productName.Validating += productName_Validating;
            // 
            // productCount
            // 
            productCount.Location = new Point(702, 313);
            productCount.Name = "productCount";
            productCount.Size = new Size(150, 31);
            productCount.TabIndex = 18;
            productCount.Validating += productCount_Validating;
            // 
            // productCost
            // 
            productCost.Location = new Point(702, 350);
            productCost.Name = "productCost";
            productCost.Size = new Size(150, 31);
            productCost.TabIndex = 19;
            productCost.Validating += productCost_Validating;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(546, 282);
            label7.Name = "label7";
            label7.Size = new Size(135, 25);
            label7.TabIndex = 20;
            label7.Text = "Наименование";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(546, 316);
            label8.Name = "label8";
            label8.Size = new Size(107, 25);
            label8.TabIndex = 21;
            label8.Text = "Количество";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(546, 350);
            label9.Name = "label9";
            label9.Size = new Size(53, 25);
            label9.TabIndex = 22;
            label9.Text = "Цена";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(546, 477);
            label12.Name = "label12";
            label12.Size = new Size(135, 25);
            label12.TabIndex = 29;
            label12.Text = "Наименование";
            // 
            // cattleName
            // 
            cattleName.Location = new Point(702, 471);
            cattleName.Name = "cattleName";
            cattleName.Size = new Size(150, 31);
            cattleName.TabIndex = 26;
            cattleName.Validating += cattleName_Validating;
            // 
            // removeCattle
            // 
            removeCattle.Location = new Point(546, 431);
            removeCattle.Name = "removeCattle";
            removeCattle.Size = new Size(306, 34);
            removeCattle.TabIndex = 25;
            removeCattle.Text = "Удалить";
            removeCattle.UseVisualStyleBackColor = true;
            removeCattle.Click += removeCattle_Click;
            // 
            // addCattle
            // 
            addCattle.Location = new Point(546, 391);
            addCattle.Name = "addCattle";
            addCattle.Size = new Size(306, 34);
            addCattle.TabIndex = 24;
            addCattle.Text = "Добавить";
            addCattle.UseVisualStyleBackColor = true;
            addCattle.Click += addCattle_Click;
            // 
            // cattleList
            // 
            cattleList.FormattingEnabled = true;
            cattleList.ItemHeight = 25;
            cattleList.Location = new Point(273, 396);
            cattleList.Name = "cattleList";
            cattleList.Size = new Size(267, 104);
            cattleList.TabIndex = 23;
            cattleList.SelectedIndexChanged += cattleList_SelectedIndexChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(546, 602);
            label13.Name = "label13";
            label13.Size = new Size(135, 25);
            label13.TabIndex = 36;
            label13.Text = "Наименование";
            // 
            // cultureName
            // 
            cultureName.Location = new Point(702, 596);
            cultureName.Name = "cultureName";
            cultureName.Size = new Size(150, 31);
            cultureName.TabIndex = 34;
            cultureName.Validating += cultureName_Validating;
            // 
            // removeCulture
            // 
            removeCulture.Location = new Point(546, 556);
            removeCulture.Name = "removeCulture";
            removeCulture.Size = new Size(306, 34);
            removeCulture.TabIndex = 33;
            removeCulture.Text = "Удалить";
            removeCulture.UseVisualStyleBackColor = true;
            removeCulture.Click += removeCulture_Click;
            // 
            // addCulture
            // 
            addCulture.Location = new Point(546, 516);
            addCulture.Name = "addCulture";
            addCulture.Size = new Size(306, 34);
            addCulture.TabIndex = 32;
            addCulture.Text = "Добавить";
            addCulture.UseVisualStyleBackColor = true;
            addCulture.Click += addCulture_Click;
            // 
            // cultureList
            // 
            cultureList.FormattingEnabled = true;
            cultureList.ItemHeight = 25;
            cultureList.Location = new Point(273, 521);
            cultureList.Name = "cultureList";
            cultureList.Size = new Size(267, 104);
            cultureList.TabIndex = 31;
            cultureList.SelectedIndexChanged += cultureList_SelectedIndexChanged;
            // 
            // harvestList
            // 
            harvestList.FormattingEnabled = true;
            harvestList.ItemHeight = 25;
            harvestList.Location = new Point(273, 201);
            harvestList.Name = "harvestList";
            harvestList.Size = new Size(267, 154);
            harvestList.TabIndex = 38;
            harvestList.SelectedIndexChanged += harvestList_SelectedIndexChanged;
            // 
            // saveFarmer
            // 
            saveFarmer.Location = new Point(344, 671);
            saveFarmer.Name = "saveFarmer";
            saveFarmer.Size = new Size(222, 34);
            saveFarmer.TabIndex = 39;
            saveFarmer.Text = "Сохранить фермера";
            saveFarmer.UseVisualStyleBackColor = true;
            saveFarmer.Click += saveFarmer_Click;
            // 
            // SetupDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 834);
            Controls.Add(saveFarmer);
            Controls.Add(harvestList);
            Controls.Add(label13);
            Controls.Add(cultureName);
            Controls.Add(removeCulture);
            Controls.Add(addCulture);
            Controls.Add(cultureList);
            Controls.Add(label12);
            Controls.Add(cattleName);
            Controls.Add(removeCattle);
            Controls.Add(addCattle);
            Controls.Add(cattleList);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(productCost);
            Controls.Add(productCount);
            Controls.Add(productName);
            Controls.Add(removeProduct);
            Controls.Add(addProduct);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
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
            Text = "Настройка фермера";
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
        private Label label4;
        private Label label5;
        private Label label6;
        private Button addProduct;
        private Button removeProduct;
        private TextBox productName;
        private TextBox productCount;
        private TextBox productCost;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label12;
        private TextBox cattleName;
        private Button removeCattle;
        private Button addCattle;
        private ListBox cattleList;
        private Label label13;
        private TextBox cultureName;
        private Button removeCulture;
        private Button addCulture;
        private ListBox cultureList;
        private ListBox harvestList;
        private Button saveFarmer;
    }
}