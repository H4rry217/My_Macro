using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Macro
{
    public partial class Main_MacroForm : Form
    {
        public CrosshairForm Crosshair = new CrosshairForm();

        private static bool MacroSwitch = false;
        private static bool ChatSwitch = false;
        private static bool CrossHairSwitch = false;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private KeyEventHandler myKeyEventHandeler = null;//按键钩子
        private KeyboardHook k_hook = new KeyboardHook();

        private MouseEventHandler myMouseHandeler = null;//按键钩子
        private MouseHook m_hook = new MouseHook();

        private Dictionary<string, Keyboard.ScanCodeShort[]> MacroChat = new Dictionary<string, Keyboard.ScanCodeShort[]>();

        public Main_MacroForm()
        {
            InitializeComponent();
            fk_u_mother();
        }

        public void stopListen()
        {
            if (myKeyEventHandeler != null)
            {
                k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                myKeyEventHandeler = null;
                k_hook.Stop();//关闭键盘钩子
            }

            if (myMouseHandeler != null)
            {
                m_hook.OnMouseActivity -= myMouseHandeler;//取消按键事件
                myMouseHandeler = null;
                m_hook.Stop();//关闭鼠标钩子
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (MacroSwitch)
            {
                if (myKeyEventHandeler != null)
                {
                    k_hook.KeyDownEvent -= myKeyEventHandeler;//取消按键事件
                    myKeyEventHandeler = null;
                    k_hook.Stop();//关闭键盘钩子
                }

                if (myMouseHandeler != null)
                {
                    m_hook.OnMouseActivity -= myMouseHandeler;//取消按键事件
                    myMouseHandeler = null;
                    m_hook.Stop();//关闭鼠标钩子
                }
            }
            else
            {
                myKeyEventHandeler = new KeyEventHandler(hook_KeyDown);
                k_hook.KeyDownEvent += myKeyEventHandeler;//钩住键按下
                k_hook.Start();//安装键盘钩子

                myMouseHandeler = new MouseEventHandler(hook_MouseButtonDown);
                m_hook.OnMouseActivity += myMouseHandeler;//钩住键按下
                m_hook.Start();//安装鼠标钩子
            }

            MacroSwitch = !MacroSwitch;
            button1.BackgroundImage = MacroSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;
        }

        private void fk_u_mother()
        {
            MacroChat.Add("CRY", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_C,
                Keyboard.ScanCodeShort.KEY_R,
                Keyboard.ScanCodeShort.KEY_Y
            });

            MacroChat.Add("RIP", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_R,
                Keyboard.ScanCodeShort.KEY_I,
                Keyboard.ScanCodeShort.KEY_P
            });

            MacroChat.Add("NOOB", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_N,
                Keyboard.ScanCodeShort.KEY_O,
                Keyboard.ScanCodeShort.KEY_O,
                Keyboard.ScanCodeShort.KEY_B
            });

            MacroChat.Add("NICE HACK", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.KEY_N,
                Keyboard.ScanCodeShort.KEY_I,
                Keyboard.ScanCodeShort.KEY_C,
                Keyboard.ScanCodeShort.KEY_E,
                Keyboard.ScanCodeShort.SPACE,
                Keyboard.ScanCodeShort.KEY_H,
                Keyboard.ScanCodeShort.KEY_A,
                Keyboard.ScanCodeShort.KEY_C,
                Keyboard.ScanCodeShort.KEY_K
            });

            MacroChat.Add(".", new Keyboard.ScanCodeShort[] {
                Keyboard.ScanCodeShort.OEM_COMMA
            });

            foreach(string chat in MacroChat.Keys)
            {
                listBox1.Items.Add(chat);
            }

        }

        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 192)
            {
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_C, false);
                Keyboard.KeyDown(Keyboard.ScanCodeShort.CAPITAL, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                Keyboard.KeyUP(Keyboard.ScanCodeShort.CAPITAL, false);
                Keyboard.KeyUP(Keyboard.ScanCodeShort.KEY_C, false);
                /*Keyboard.KeyDown(Keyboard.ScanCodeShort.CONTROL, false);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_V);
                Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);*/

            }

            if ((int)ModifierKeys == (int)Keys.Control)
            {
                switch (e.KeyValue)
                {
                    case (int)Keys.NumPad1:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.KeyDown(Keyboard.ScanCodeShort.KEY_C, false);
                        Keyboard.KeyDown(Keyboard.ScanCodeShort.CAPITAL, false);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.KeyUP(Keyboard.ScanCodeShort.CAPITAL, false);
                        Keyboard.KeyUP(Keyboard.ScanCodeShort.KEY_C, false);
                        break;
                    case (int)Keys.NumPad4:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(50);
                        //Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(300);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(300);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.LEFT, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        break;
                    case (int)Keys.NumPad7:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Thread.Sleep(100);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Thread.Sleep(100);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.UP, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        break;
                    case (int)Keys.NumPad8:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.SPACE);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;
                    case (int)Keys.NumPad9:
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.DOWN, true);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.SPACE);
                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_M);
                        break;
                    default:
                        return;
                }

            }

        }

        private void hook_MouseButtonDown(object sender, MouseEventArgs e)
        {
            //label9.Text = e.

            if (e.Button.Equals(MouseButtons.Middle))
            {
                if (ChatSwitch)
                {
                    if (listBox1.SelectedItem == null) return;

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);

                    foreach (Keyboard.ScanCodeShort key in MacroChat[listBox1.SelectedItem.ToString()])
                    {
                        Keyboard.FuckingPressKey(key);
                    }

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);

                    return;
                }
            }

            /*switch (e.Button)
            {
                case MouseButtons.XButton1:

                    if (ChatSwitch)
                    {
                        if (listBox1.SelectedItem == null) return;

                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_T);

                        foreach (Keyboard.ScanCodeShort key in MacroChat[listBox1.SelectedItem.ToString()])
                        {
                            Keyboard.FuckingPressKey(key);
                        }

                        Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.RETURN);

                        return;
                    }

                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_3);
                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_2);
                    Keyboard.Mouse_Right_Dowm();
                    Keyboard.Mouse_Left_Dowm();

                    Keyboard.Mouse_Left_Up();
                    Keyboard.Mouse_Right_Up();
                    break;
                case MouseButtons.XButton2:
                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_3);
                    Keyboard.FuckingPressKey(Keyboard.ScanCodeShort.KEY_1);
                    break;

            }*/
        }

        private void Main_MacroForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            stopListen();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ChatSwitch = !ChatSwitch;
            button2.BackgroundImage = ChatSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            CrossHairSwitch = !CrossHairSwitch;
            button3.BackgroundImage = CrossHairSwitch ? Properties.Resources.switch_on : Properties.Resources.switch_off;

            if (CrossHairSwitch)
            {
                Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                Crosshair.Show();
            }
            else
            {
                Crosshair.Hide();
            }
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Crosshair.Location = (Point)new Size((int)numericUpDown1.Value, (int)numericUpDown2.Value);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Author:HarryZ \n" +
                "Email:1339544914@qq.com\n" +
                "Welcome to fuck me"
                );
        }
    }
}
