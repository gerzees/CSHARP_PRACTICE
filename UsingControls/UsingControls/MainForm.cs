namespace UsingControls
{
    public partial class MainForm : Form
    {
        Random random = new Random(37);
        public MainForm()
        {
            InitializeComponent();

            lvDummy.Columns.Add("Name");
            lvDummy.Columns.Add("Depth");
        }

        void TreeToList()
        {
            lvDummy.Items.Clear();
            foreach (TreeNode root in tvDummy.Nodes)
            {
                TreeToList(root);
            }
        }

        void TreeToList(TreeNode node)
        {
            lvDummy.Items.Add(
                new ListViewItem(new string[] { node.Text, node.FullPath.Count(f => f == '\\').ToString() }));

            foreach (TreeNode child in node.Nodes)
            {
                TreeToList(child);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var Fonts = FontFamily.Families; // 운영체제에 설치되어 있는 폰트 목록 검색
            foreach (FontFamily font in Fonts) // cboFont 컨트롤에 각 폰트 이름 추가
            {
                cboFont.Items.Add(font.Name);
            }

        }

        void ChangeFont()
        {
            if (cboFont.SelectedIndex < 0) // cboFont에서 선택한 항목이 없으면 메소드 종료
            {
                return;
            }

            FontStyle style = FontStyle.Regular;//FontStyle 개체를 초기화합니다

            if (chkBold.Checked)
            {
                style |= FontStyle.Bold;
            }

            if (chkItalic.Checked)
            {
                style |= FontStyle.Italic;
            }

            if (cboFont.SelectedItem == null)
            {
                return;
            }

            txtSampleText.Font = new Font((string)cboFont.SelectedItem, 10, style);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cboFont_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void chkBold_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void chkItalic_CheckedChanged(object sender, EventArgs e)
        {
            ChangeFont();
        }

        private void tbDummy_Scroll(object sender, EventArgs e)
        {
            pgDummy.Value = tbDummy.Value; // 슬라이더의 위치에 따라 프로그레스바의 내용도 변경
        }

        private void btnMsgBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtSampleText.Text, "MessageBox Test", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnModal_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Modal Form";
            frm.Width = 300;
            frm.Height = 100;
            frm.BackColor = Color.Red;
            frm.ShowDialog(); // modal창을 띄웁니다.
        }

        private void btnModaless_Click(object sender, EventArgs e)
        {
            Form frm = new Form();
            frm.Text = "Modaless Form";
            frm.Width = 300;
            frm.Height = 100;
            frm.BackColor = Color.Green;
            frm.Show(); // modaless창을 띄웁니다.
        }

        private void btnAddRoot_Click(object sender, EventArgs e)
        {
            tvDummy.Nodes.Add(random.Next().ToString());
            TreeToList();
        }

        private void btnAddChild_Click(object sender, EventArgs e)
        {
            if(tvDummy.SelectedNode == null)
            {
                MessageBox.Show("선택된 노드가 없습니다",
                    "TreeView Test", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            tvDummy.SelectedNode.Nodes.Add(random.Next().ToString());
            tvDummy.SelectedNode.Expand();
            TreeToList();
        }
    }
}
