using System;
using System.Windows.Forms;

namespace fmControls
{
    public partial class CommentsWindow : Form
    {
        public CommentsWindow()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        public string GetCommentText()
        {
            return textBox1.Text;
        }

        public  void SetCommentText(string text)
        {
            textBox1.Text = text;
        }

        private string m_objectName = "";
        public void SetCommentedObjectName(string objectName)
        {
            m_objectName = objectName;
        }

        private void CommentsWindow_Load(object sender, EventArgs e)
        {
            label1.Text = "Comments to " + m_objectName + ":";
        }
    }
}
