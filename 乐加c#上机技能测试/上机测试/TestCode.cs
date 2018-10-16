using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace testPartner
{
    public class Node
    {
        public string abc;
        public List<Node> subnode = new List<Node>();
    }
    class TestCode
    {
        System.Drawing.Image img01;
        public TestCode()
        {
            //从文件中读取一张图片
            img01 = System.Drawing.Image.FromFile("sd01.png");
        }
        Action updateevent;
        public void update()
        {
            if (updateevent != null)
                updateevent();
        }

        int _canvaswidth;
        int _canvasheight;
        float startAngle = 0;

        public void Test01(PictureBox pic)
        {
            //取pic作为画布尺寸
            _canvaswidth = pic.Width;
            _canvasheight = pic.Height;

            PaintEventHandler callback = (s, e) =>
            {
                e.Graphics.Clear(System.Drawing.Color.Black);
                _draw01(e.Graphics);
            };
            //指定pic的刷新函数
            pic.Paint += callback;

            //刷新pic,这会调用paint函数
            pic.Refresh();

            pic.Paint -= callback;
            updateevent = () =>
                {
                    startAngle += 3;
                    pic.Paint += callback;
                    pic.Refresh();

                    pic.Paint -= callback;
                };
        }
        void _draw01(System.Drawing.Graphics g)
        {
            float w = 3;
            float h = 3;
            float x = _canvaswidth / 2.0f;
            float y = _canvasheight / 2.0f;
            g.DrawImage(img01, x + startAngle % 100, y, w, h);
        }



        Random ran = new Random();
        int nodeindex = 0;
        Node GenNode(int depth = 3, int maxsize = 5)
        {
            nodeindex++;
            Node n = new Node();
            n.abc = "test string." + nodeindex.ToString("D03");


            return n;
        }
        void FillNode(TreeNode treenode, Node datanode)
        {
            treenode.Text = datanode.abc;
            foreach (var d in datanode.subnode)
            {
                TreeNode nn = new TreeNode();
                FillNode(nn, d);
                treenode.Nodes.Add(nn);
            }
        }
        public void Test02(TreeView treeview)
        {
            nodeindex = 0;
            Node info = GenNode(3, 5);
            treeview.Nodes.Clear();
            TreeNode node = new TreeNode();
            FillNode(node, info);
            treeview.Nodes.Add(node);
            treeview.ExpandAll();

            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "notepad";
            p.StartInfo.Arguments = "out.xml";
            p.Start();
            updateevent = () =>
              {
              };
        }
        public void Test03(TreeView treeview)
        {
            treeview.Nodes.Clear();

            Node outnode = new Node();
            outnode.abc = "从out.xml中读取";

            TreeNode node = new TreeNode();
            FillNode(node, outnode);
            treeview.Nodes.Add(node);
            treeview.ExpandAll();


            updateevent = () =>
            {
            };
        }
        public void Test04(PictureBox pic)
        {
            PaintEventHandler callback = (s, e) =>
            {
                e.Graphics.Clear(System.Drawing.Color.Black);
                _draw04(e.Graphics);
            };
            //指定pic的刷新函数
            pic.Paint += callback;

            //刷新pic,这会调用paint函数
            pic.Refresh();

            pic.Paint -= callback;
            updateevent = () =>
            {

            };
        }
        void _draw04(System.Drawing.Graphics g)
        {

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    int uvx = ran.Next(this.img01.Width - 10);
                    int uvy = ran.Next(this.img01.Height - 10);
                    RectangleF src = new RectangleF(uvx, uvy, 10, 10);
                    RectangleF dest = new RectangleF(x * (10+1), y * (10+1), 10, 10);

                    g.DrawImage(this.img01, dest, src, GraphicsUnit.Pixel);
                }
            }

        }

    }
}
