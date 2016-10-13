using System;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Lab3
{
	public class UI : Form
	{
		ComboBox fromBox;
		ComboBox toBox;
		RadioButton firstClass;
		RadioButton secondClass;
		RadioButton oneWay;
		RadioButton returnWay;
		RadioButton noDiscount;
		RadioButton twentyDiscount;
		RadioButton fortyDiscount;
		ComboBox payment;
        Button pay;
        TableLayoutPanel discountGrid = new TableLayoutPanel();
        TableLayoutPanel wayGrid = new TableLayoutPanel();
        TableLayoutPanel classGrid = new TableLayoutPanel();

        public UI ()
		{
			initializeControls ();
		}

		

#region Set-up -- don't look at it
		private void initializeControls()
		{
			// Set label
			this.Text = "MSO Lab Exercise III";
			// this.FormBorderStyle = FormBorderStyle.FixedSingle;
			this.Width = 500;
			this.Height = 210;
			// Set layout
			var grid = new TableLayoutPanel ();
			grid.Dock = DockStyle.Fill;
			grid.Padding = new Padding (5);
			this.Controls.Add (grid);
			grid.RowCount = 4;
			grid.RowStyles.Add (new RowStyle (SizeType.Absolute, 20));
			grid.RowStyles.Add (new RowStyle (SizeType.Percent, 100));
			grid.RowStyles.Add (new RowStyle (SizeType.Absolute, 20));
			grid.RowStyles.Add (new RowStyle (SizeType.Absolute, 40));
			grid.ColumnCount = 6;
			for (int i = 0; i < 6; i++)
			{
				ColumnStyle c = new ColumnStyle (SizeType.Percent, 16.66666f);
				grid.ColumnStyles.Add (c);
			}
			// Create From and To
			var fromLabel = new Label ();
			fromLabel.Text = "Vanaf:";
			fromLabel.TextAlign = ContentAlignment.MiddleRight;
			grid.Controls.Add (fromLabel, 0, 0);
			fromLabel.Dock = DockStyle.Fill;
			fromBox = new ComboBox ();
			fromBox.DropDownStyle = ComboBoxStyle.DropDownList;
			fromBox.Items.AddRange (Station.StationNaam);
			fromBox.SelectedIndex = 0;
			grid.Controls.Add (fromBox, 1, 0);
			grid.SetColumnSpan (fromBox, 2);
			fromBox.Dock = DockStyle.Fill;
			var toLabel = new Label ();
			toLabel.Text = "Naar:";
			toLabel.TextAlign = ContentAlignment.MiddleRight;
			grid.Controls.Add (toLabel, 3, 0);
			toLabel.Dock = DockStyle.Fill;
			toBox = new ComboBox ();
			toBox.DropDownStyle = ComboBoxStyle.DropDownList;
			toBox.Items.AddRange (Station.StationNaam);
			toBox.SelectedIndex = 0;
			grid.Controls.Add (toBox, 4, 0);
			grid.SetColumnSpan (toBox, 2);
			toBox.Dock = DockStyle.Fill;
			// Create groups
			GroupBox classGroup = new GroupBox ();
			classGroup.Text = "Klasse";
			classGroup.Dock = DockStyle.Fill;
			grid.Controls.Add (classGroup, 0, 1);
			grid.SetColumnSpan (classGroup, 2);
			
			classGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			classGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			classGrid.Dock = DockStyle.Fill;
			classGroup.Controls.Add (classGrid);
			GroupBox wayGroup = new GroupBox ();
			wayGroup.Text = "Soort Reis";
			wayGroup.Dock = DockStyle.Fill;
			grid.Controls.Add (wayGroup, 2, 1);
			grid.SetColumnSpan (wayGroup, 2);
			
			wayGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			wayGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 50));
			wayGrid.Dock = DockStyle.Fill;
			wayGroup.Controls.Add (wayGrid);
			GroupBox discountGroup = new GroupBox ();
			discountGroup.Text = "Soort Railcard:";
			discountGroup.Dock = DockStyle.Fill;
			grid.Controls.Add (discountGroup, 4, 1);
			grid.SetColumnSpan (discountGroup, 2);
			
			discountGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 33.33333f));
			discountGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 33.33333f));
			discountGrid.RowStyles.Add (new RowStyle (SizeType.Percent, 33.33333f));
			discountGrid.Dock = DockStyle.Fill;
			discountGroup.Controls.Add (discountGrid);
			// Create radio buttons
			firstClass = new RadioButton ();
			firstClass.Text = "Eerste Klasse";
			firstClass.Checked = true;
			classGrid.Controls.Add (firstClass);
			secondClass = new RadioButton ();
			secondClass.Text = "Tweede Klasse";
			classGrid.Controls.Add (secondClass);
			oneWay = new RadioButton ();
			oneWay.Text = "Enkele Reis";
			oneWay.Checked = true;
			wayGrid.Controls.Add (oneWay);
			returnWay = new RadioButton ();
			returnWay.Text = "Retour Reis";
			wayGrid.Controls.Add (returnWay);
			noDiscount = new RadioButton ();
			noDiscount.Text = "Geen Korting";
			noDiscount.Checked = true;
			discountGrid.Controls.Add (noDiscount);
			twentyDiscount = new RadioButton ();
			twentyDiscount.Text = "20% Korting";
			discountGrid.Controls.Add (twentyDiscount);
			fortyDiscount = new RadioButton ();
			fortyDiscount.Text = "40% Korting";
			discountGrid.Controls.Add (fortyDiscount);
			// Payment option
			Label paymentLabel = new Label ();
			paymentLabel.Text = "Betaling via:";
			paymentLabel.Dock = DockStyle.Fill;
			paymentLabel.TextAlign = ContentAlignment.MiddleRight;
			grid.Controls.Add (paymentLabel, 0, 2);
			payment = new ComboBox ();
			payment.DropDownStyle = ComboBoxStyle.DropDownList;
			payment.Items.AddRange (new String[] { "Credit card", "Debit card", "Contant" });
			payment.SelectedIndex = 0;
			payment.Dock = DockStyle.Fill;
			grid.Controls.Add (payment, 1, 2);
			grid.SetColumnSpan (payment, 5);
			// Pay button
			pay = new Button ();
			pay.Text = "Betaal";
			pay.Dock = DockStyle.Fill;
			grid.Controls.Add (pay, 0, 3);
			grid.SetColumnSpan (pay, 6);
			// Set up event
			pay.Click += (object sender, EventArgs e) => PrijsBerekenaar.BerekenPrijs(getUIInfo());
		}

		private UIInfo getUIInfo()
		{
            var CheckedKlasse = classGrid.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            var CheckedReistype = wayGrid.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked);
            var CheckedRailcard = discountGrid.Controls.OfType<RadioButton>().FirstOrDefault(p => p.Checked);

            return new UIInfo ((string)fromBox.SelectedItem,
				               (string)toBox.SelectedItem,
				                KiesKlasse.KrijgKlasse(CheckedKlasse.Text), 
                                KiesReisType.KrijgReisType(CheckedReistype.Text),
                                KiesRailcard.KrijgRailcard(CheckedRailcard.Text), 
                                KiesBetaalmethode.KrijgBetaalmethode((string)payment.SelectedItem));
		}
#endregion
	}
}

