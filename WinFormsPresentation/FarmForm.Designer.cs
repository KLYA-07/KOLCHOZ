namespace WinFormsPresentation
{
    partial class FarmForm
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
            farmerList = new ListBox();
            addButton = new Button();
            removeButton = new Button();
            readFarmer = new Button();
            changeFarmer = new Button();
            exchangeProduct = new Button();
            harvestSort = new Button();
            SuspendLayout();
            // 
            // farmerList
            // 
            farmerList.FormattingEnabled = true;
            farmerList.ItemHeight = 25;
            farmerList.Location = new Point(461, 12);
            farmerList.Name = "farmerList";
            farmerList.SelectionMode = SelectionMode.MultiSimple;
            farmerList.Size = new Size(639, 554);
            farmerList.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(461, 572);
            addButton.Name = "addButton";
            addButton.Size = new Size(283, 34);
            addButton.TabIndex = 1;
            addButton.Text = "Добавить фермера";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // removeButton
            // 
            removeButton.Location = new Point(817, 572);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(283, 34);
            removeButton.TabIndex = 2;
            removeButton.Text = "Удалить фермера";
            removeButton.UseVisualStyleBackColor = true;
            removeButton.Click += removeButton_Click;
            // 
            // readFarmer
            // 
            readFarmer.Location = new Point(461, 612);
            readFarmer.Name = "readFarmer";
            readFarmer.Size = new Size(283, 34);
            readFarmer.TabIndex = 3;
            readFarmer.Text = "Прочитать фермера";
            readFarmer.UseVisualStyleBackColor = true;
            readFarmer.Click += readFarmer_Click;
            // 
            // changeFarmer
            // 
            changeFarmer.Location = new Point(817, 612);
            changeFarmer.Name = "changeFarmer";
            changeFarmer.Size = new Size(283, 34);
            changeFarmer.TabIndex = 4;
            changeFarmer.Text = "Изменить фермера";
            changeFarmer.UseVisualStyleBackColor = true;
            changeFarmer.Click += changeFarmer_Click;
            // 
            // exchangeProduct
            // 
            exchangeProduct.Location = new Point(461, 652);
            exchangeProduct.Name = "exchangeProduct";
            exchangeProduct.Size = new Size(283, 34);
            exchangeProduct.TabIndex = 5;
            exchangeProduct.Text = "Произвести покупку";
            exchangeProduct.UseVisualStyleBackColor = true;
            exchangeProduct.Click += exchangeProduct_Click;
            // 
            // harvestSort
            // 
            harvestSort.Location = new Point(817, 652);
            harvestSort.Name = "harvestSort";
            harvestSort.Size = new Size(283, 34);
            harvestSort.TabIndex = 6;
            harvestSort.Text = "Отсортировать по урожаю";
            harvestSort.UseVisualStyleBackColor = true;
            harvestSort.Click += harvestSort_Click;
            // 
            // FarmForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1691, 827);
            Controls.Add(harvestSort);
            Controls.Add(exchangeProduct);
            Controls.Add(changeFarmer);
            Controls.Add(readFarmer);
            Controls.Add(removeButton);
            Controls.Add(addButton);
            Controls.Add(farmerList);
            Name = "FarmForm";
            Text = "Фермеры";
            ResumeLayout(false);
        }

        #endregion

        private ListBox farmerList;
        private Button addButton;
        private Button removeButton;
        private Button readFarmer;
        private Button changeFarmer;
        private Button exchangeProduct;
        private Button harvestSort;
    }
}
