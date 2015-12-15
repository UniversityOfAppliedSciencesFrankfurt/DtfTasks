using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SendsSMS
{
    public partial class UserCredential : Form
    {
        public UserCredential(string body)
        {
            
            InitializeComponent();
            this.body.Text = body;

            //ConboBox1
            this.comboBox1.Items.AddRange(getCountryList());
            this.comboBox1.SelectedItem = "Select Country";
            
        }


        #region Public Properties
        public string eMailFrom { get; set; }
        public string pass { get; set; }
        public string PhnNumber { get; set; }
        public string eBody { get; set; }
        #endregion Propurties

        /// <summary>
        /// Check Eamil and password and set all public propurties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (eMail.Text != string.Empty && passWord.Text != string.Empty)
            {
                this.eMailFrom = eMail.Text;
                this.pass = passWord.Text;
                if (Number() != string.Empty)
                {
                    this.PhnNumber = Number();
                    this.eBody = body.Text;
                    this.Hide();
                }
                else
                {
                    empty3.ForeColor = Color.Red;
                    empty3.Text = "Phone Number is Empty !!";
                }
            }
            else
            {
                empty1.ForeColor = Color.Red;
                empty1.Text = "Email or Password is Empty !!";
            }
        }

        /// <summary>
        /// Check first digit of mobile number is zero or not if  zero it will remove and add country calling code with mobile number
        /// </summary>
        /// <returns>Mobile number without zero</returns>
        private string Number()
        {
            if(smsTo.Text != string.Empty)
            {
                return smsTo.Text.Substring(0, 1) == "0" ?string.Format("00{0}{1}",callingCode(),smsTo.Text.Substring(1,smsTo.Text.Length-1)) : string.Format("00{0}{1}",callingCode(), smsTo.Text);
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// Here used a xml file for list of country name
        /// </summary>
        /// <returns></returns>
        private object[] getCountryList()
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(@"C:\Users\Summon\documents\visual studio 2013\Projects\DurableTaskFramework\SendsSMS\Countries.xml");
            XmlNodeList list = xmlDoc.SelectNodes("countries/country");
            object[] objList = new object[list.Count];
            objList[0] = "Select Country";
            for (int i = 1; i < list.Count; i++)
            {
                objList[i] = list.Item(i).Attributes["name"].Value;
            }
            return objList;
        }


        /// <summary>
        /// Here used a xml file for getting country calling code 
        /// </summary>
        /// <returns>country calling code</returns>

        private string callingCode()
        {
            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(@"C:\Users\Summon\documents\visual studio 2013\Projects\DurableTaskFramework\SendsSMS\Countries.xml");
            XmlNodeList list = xmlDoc.SelectNodes("countries/country");
            var code = "";
            for (int i = 1; i < list.Count; i++)
            {
                if (list.Item(i).Attributes["name"].Value == comboBox1.Text)
                    code = list.Item(i).Attributes["phoneCode"].Value;
            }
            return code;
        }

        /// <summary>
        /// For register dialog box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Register :\n www.websms.com");
        }

    }
}
