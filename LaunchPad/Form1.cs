using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace LaunchPad
{
  public partial class Form1 : Form
  {
    
    CLaunchPad m_launchPad = new CLaunchPad();
    Thread[] m_thButton = new Thread[CValueObject.g_nThreadMax];
    SettingForm m_dlgSetting = new SettingForm();
    public Form1()
    {
      InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
      this.KeyPreview = true;

      m_launchPad.SetButtonValue(0, btn_1);
      m_launchPad.SetButtonValue(1, btn_2);
      m_launchPad.SetButtonValue(2, btn_3);
      m_launchPad.SetButtonValue(3, btn_4);
      m_launchPad.SetButtonValue(4, btn_5);
      m_launchPad.SetButtonValue(5, btn_6);
      m_launchPad.SetButtonValue(6, btn_7);
      m_launchPad.SetButtonValue(7, btn_8);
      m_launchPad.SetButtonValue(8, btn_9);
      m_launchPad.SetButtonValue(9, btn_10);
      m_launchPad.SetButtonValue(10, btn_11);
      m_launchPad.SetButtonValue(11, btn_12);
      m_launchPad.SetButtonValue(12, btn_13);
      m_launchPad.SetButtonValue(13, btn_14);
      m_launchPad.SetButtonValue(14, btn_15);
      m_launchPad.SetButtonValue(15, btn_16);

      m_thButton[0] = new Thread(new ThreadStart(m_launchPad.CtrlBtn1));
      m_thButton[1] = new Thread(new ThreadStart(m_launchPad.CtrlBtn2));
      m_thButton[2] = new Thread(new ThreadStart(m_launchPad.CtrlBtn3));
      m_thButton[3] = new Thread(new ThreadStart(m_launchPad.CtrlBtn4));
      m_thButton[4] = new Thread(new ThreadStart(m_launchPad.CtrlBtn5));
      m_thButton[5] = new Thread(new ThreadStart(m_launchPad.CtrlBtn6));
      m_thButton[6] = new Thread(new ThreadStart(m_launchPad.CtrlBtn7));
      m_thButton[7] = new Thread(new ThreadStart(m_launchPad.CtrlBtn8));
      m_thButton[8] = new Thread(new ThreadStart(m_launchPad.CtrlBtn9));
      m_thButton[9] = new Thread(new ThreadStart(m_launchPad.CtrlBtn10));
      m_thButton[10] = new Thread(new ThreadStart(m_launchPad.CtrlBtn11));
      m_thButton[11] = new Thread(new ThreadStart(m_launchPad.CtrlBtn12));
      m_thButton[12] = new Thread(new ThreadStart(m_launchPad.CtrlBtn13));
      m_thButton[13] = new Thread(new ThreadStart(m_launchPad.CtrlBtn14));
      m_thButton[14] = new Thread(new ThreadStart(m_launchPad.CtrlBtn15));
      m_thButton[15] = new Thread(new ThreadStart(m_launchPad.CtrlBtn16));
      for (int i = 0; i < CValueObject.g_nThreadMax; i++)
      {
        m_thButton[i].Start();
      }
    }

    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
    {
      for (int i = 0; i < CValueObject.g_nThreadMax; i++)
      {
        m_thButton[i].Abort();
      }
    }

    private void btn_Setting_Click(object sender, EventArgs e)
    {
      m_dlgSetting.Show();
      m_dlgSetting.UpdateData();
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      int nNowKey = -1;
      switch (e.KeyCode)
      {
        case Keys.Escape: CValueObject.g_KeyStatus[(int)KeyBoard.Key_ESC] = 1; nNowKey = (int)KeyBoard.Key_ESC; break;
        case Keys.F1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F1] = 1; nNowKey = (int)KeyBoard.Key_F1; break;
        case Keys.F2: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F2] = 1; nNowKey = (int)KeyBoard.Key_F2; break;
        case Keys.F3: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F3] = 1; nNowKey = (int)KeyBoard.Key_F3; break;
        case Keys.F4: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F4] = 1; nNowKey = (int)KeyBoard.Key_F4; break;
        case Keys.F5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F5] = 1; nNowKey = (int)KeyBoard.Key_F5; break;
        case Keys.F6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F6] = 1; nNowKey = (int)KeyBoard.Key_F6; break;
        case Keys.F7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F7] = 1; nNowKey = (int)KeyBoard.Key_F7; break;
        case Keys.F8: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F8] = 1; nNowKey = (int)KeyBoard.Key_F8; break;
        case Keys.F9: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F9] = 1; nNowKey = (int)KeyBoard.Key_F9; break;
        case Keys.F10: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F10] = 1; nNowKey = (int)KeyBoard.Key_F10; break;
        case Keys.F11: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F11] = 1; nNowKey = (int)KeyBoard.Key_F11; break;
        case Keys.F12: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F12] = 1; nNowKey = (int)KeyBoard.Key_F12; break;

        case Keys.PrintScreen: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PrintScreen] = 1; nNowKey = (int)KeyBoard.Key_PrintScreen; break;
        case Keys.Scroll: CValueObject.g_KeyStatus[(int)KeyBoard.Key_ScrollLock] = 1; nNowKey = (int)KeyBoard.Key_ScrollLock; break;
        case Keys.Pause: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PauseBreak] = 1; nNowKey = (int)KeyBoard.Key_PauseBreak; break;

        case Keys.Oemtilde: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Tilde] = 1; nNowKey = (int)KeyBoard.Key_Tilde; break;
        case Keys.D1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_1] = 1; nNowKey = (int)KeyBoard.Key_1; break;
        case Keys.D2: CValueObject.g_KeyStatus[(int)KeyBoard.Key_2] = 1; nNowKey = (int)KeyBoard.Key_2; break;
        case Keys.D3: CValueObject.g_KeyStatus[(int)KeyBoard.Key_3] = 1; nNowKey = (int)KeyBoard.Key_3; break;
        case Keys.D4: CValueObject.g_KeyStatus[(int)KeyBoard.Key_4] = 1; nNowKey = (int)KeyBoard.Key_4; break;
        case Keys.D5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_5] = 1; nNowKey = (int)KeyBoard.Key_5; break;
        case Keys.D6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_6] = 1; nNowKey = (int)KeyBoard.Key_6; break;
        case Keys.D7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_7] = 1; nNowKey = (int)KeyBoard.Key_7; break;
        case Keys.D8: CValueObject.g_KeyStatus[(int)KeyBoard.Key_8] = 1; nNowKey = (int)KeyBoard.Key_8; break;
        case Keys.D9: CValueObject.g_KeyStatus[(int)KeyBoard.Key_9] = 1; nNowKey = (int)KeyBoard.Key_9; break;
        case Keys.D0: CValueObject.g_KeyStatus[(int)KeyBoard.Key_0] = 1; nNowKey = (int)KeyBoard.Key_0; break;

        case Keys.Tab: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Tap] = 1; nNowKey = (int)KeyBoard.Key_Tap; break;
        case Keys.Q: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Q] = 1; nNowKey = (int)KeyBoard.Key_Q; break;
        case Keys.W: CValueObject.g_KeyStatus[(int)KeyBoard.Key_W] = 1; nNowKey = (int)KeyBoard.Key_W; break;
        case Keys.E: CValueObject.g_KeyStatus[(int)KeyBoard.Key_E] = 1; nNowKey = (int)KeyBoard.Key_E; break;
        case Keys.R: CValueObject.g_KeyStatus[(int)KeyBoard.Key_R] = 1; nNowKey = (int)KeyBoard.Key_R; break;
        case Keys.T: CValueObject.g_KeyStatus[(int)KeyBoard.Key_T] = 1; nNowKey = (int)KeyBoard.Key_T; break;
        case Keys.Y: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Y] = 1; nNowKey = (int)KeyBoard.Key_Y; break;
        case Keys.U: CValueObject.g_KeyStatus[(int)KeyBoard.Key_U] = 1; nNowKey = (int)KeyBoard.Key_U; break;
        case Keys.I: CValueObject.g_KeyStatus[(int)KeyBoard.Key_I] = 1; nNowKey = (int)KeyBoard.Key_I; break;
        case Keys.O: CValueObject.g_KeyStatus[(int)KeyBoard.Key_O] = 1; nNowKey = (int)KeyBoard.Key_O; break;
        case Keys.P: CValueObject.g_KeyStatus[(int)KeyBoard.Key_P] = 1; nNowKey = (int)KeyBoard.Key_P; break;
        case Keys.OemOpenBrackets: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LSquareBracket] = 1; nNowKey = (int)KeyBoard.Key_LSquareBracket; break;
        case Keys.Oem6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RSquareBracket] = 1; nNowKey = (int)KeyBoard.Key_RSquareBracket; break;
        case Keys.Oem5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_BackSlash] = 1; nNowKey = (int)KeyBoard.Key_BackSlash; break;

        case Keys.Capital: CValueObject.g_KeyStatus[(int)KeyBoard.Key_CapsLock] = 1; nNowKey = (int)KeyBoard.Key_CapsLock; break;
        case Keys.A: CValueObject.g_KeyStatus[(int)KeyBoard.Key_A] = 1; nNowKey = (int)KeyBoard.Key_A; break;
        case Keys.S: CValueObject.g_KeyStatus[(int)KeyBoard.Key_S] = 1; nNowKey = (int)KeyBoard.Key_S; break;
        case Keys.D: CValueObject.g_KeyStatus[(int)KeyBoard.Key_D] = 1; nNowKey = (int)KeyBoard.Key_D; break;
        case Keys.F: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F] = 1; nNowKey = (int)KeyBoard.Key_F; break;
        case Keys.G: CValueObject.g_KeyStatus[(int)KeyBoard.Key_G] = 1; nNowKey = (int)KeyBoard.Key_G; break;
        case Keys.H: CValueObject.g_KeyStatus[(int)KeyBoard.Key_H] = 1; nNowKey = (int)KeyBoard.Key_H; break;
        case Keys.J: CValueObject.g_KeyStatus[(int)KeyBoard.Key_J] = 1; nNowKey = (int)KeyBoard.Key_J; break;
        case Keys.K: CValueObject.g_KeyStatus[(int)KeyBoard.Key_K] = 1; nNowKey = (int)KeyBoard.Key_K; break;
        case Keys.L: CValueObject.g_KeyStatus[(int)KeyBoard.Key_L] = 1; nNowKey = (int)KeyBoard.Key_L; break;
        case Keys.Oem1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Semicolon] = 1; nNowKey = (int)KeyBoard.Key_Semicolon; break;
        case Keys.Oem7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Apostrophe] = 1; nNowKey = (int)KeyBoard.Key_Apostrophe; break;
        case Keys.Return: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Enter] = 1; nNowKey = (int)KeyBoard.Key_Enter; break;

        //case Keys.ShiftKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LShift] = 0; CValueObject.g_KeyStatus[(int)KeyBoard.Key_RShift] = 0; break; 
        case Keys.LShiftKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LShift] = 1; nNowKey = (int)KeyBoard.Key_LShift; break;
        case Keys.Z: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Z] = 1; nNowKey = (int)KeyBoard.Key_Z; break;
        case Keys.X: CValueObject.g_KeyStatus[(int)KeyBoard.Key_X] = 1; nNowKey = (int)KeyBoard.Key_X; break;
        case Keys.C: CValueObject.g_KeyStatus[(int)KeyBoard.Key_C] = 1; nNowKey = (int)KeyBoard.Key_C; break;
        case Keys.V: CValueObject.g_KeyStatus[(int)KeyBoard.Key_V] = 1; nNowKey = (int)KeyBoard.Key_V; break;
        case Keys.B: CValueObject.g_KeyStatus[(int)KeyBoard.Key_B] = 1; nNowKey = (int)KeyBoard.Key_B; break;
        case Keys.N: CValueObject.g_KeyStatus[(int)KeyBoard.Key_N] = 1; nNowKey = (int)KeyBoard.Key_N; break;
        case Keys.M: CValueObject.g_KeyStatus[(int)KeyBoard.Key_M] = 1; nNowKey = (int)KeyBoard.Key_M; break;
        case Keys.Oemcomma: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Comma] = 1; nNowKey = (int)KeyBoard.Key_Comma; break;
        case Keys.OemPeriod: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Period] = 1; nNowKey = (int)KeyBoard.Key_Period; break;
        case Keys.OemQuestion: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Slash] = 1; nNowKey = (int)KeyBoard.Key_Slash; break;

        //case Keys.ControlKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LCtrl] = 0; CValueObject.g_KeyStatus[(int)KeyBoard.Key_RCtrl] = 0; break;
        case Keys.LControlKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LCtrl] = 1; nNowKey = (int)KeyBoard.Key_LCtrl; break;
        case Keys.LWin: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LWin] = 1; nNowKey = (int)KeyBoard.Key_LWin; break;
        case Keys.Space: CValueObject.g_KeyStatus[(int)KeyBoard.Key_SpaceBar] = 1; nNowKey = (int)KeyBoard.Key_SpaceBar; break;
        case Keys.KanaMode: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RAlt] = 1; nNowKey = (int)KeyBoard.Key_RAlt; break;
        //FN key
        case Keys.HanjaMode: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RCtrl] = 1; nNowKey = (int)KeyBoard.Key_RCtrl; break;

        case Keys.Insert: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Insert] = 1; nNowKey = (int)KeyBoard.Key_Insert; break;
        case Keys.Home: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Home] = 1; nNowKey = (int)KeyBoard.Key_Home; break;
        case Keys.PageUp: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PageUp] = 1; nNowKey = (int)KeyBoard.Key_PageUp; break;
        case Keys.Delete: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Delete] = 1; nNowKey = (int)KeyBoard.Key_Delete; break;
        case Keys.End: CValueObject.g_KeyStatus[(int)KeyBoard.Key_End] = 1; nNowKey = (int)KeyBoard.Key_End; break;
        case Keys.PageDown: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PageDown] = 1; nNowKey = (int)KeyBoard.Key_PageDown; break;

        case Keys.Up: CValueObject.g_KeyStatus[(int)KeyBoard.Key_UpArrow] = 1; nNowKey = (int)KeyBoard.Key_UpArrow; break;
        case Keys.Left: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LeftArrow] = 1; nNowKey = (int)KeyBoard.Key_LeftArrow; break;
        case Keys.Down: CValueObject.g_KeyStatus[(int)KeyBoard.Key_DownArrow] = 1; nNowKey = (int)KeyBoard.Key_DownArrow; break;
        case Keys.Right: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RightArrow] = 1; nNowKey = (int)KeyBoard.Key_RightArrow; break;

        case Keys.NumLock: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumberLock] = 1; nNowKey = (int)KeyBoard.Key_NumberLock; break;
        case Keys.Divide: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumSlash] = 1; nNowKey = (int)KeyBoard.Key_NumSlash; break;
        case Keys.Multiply: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumAsterisk] = 1; nNowKey = (int)KeyBoard.Key_NumAsterisk; break;
        case Keys.Subtract: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumHyphen] = 1; nNowKey = (int)KeyBoard.Key_NumHyphen; break;
        case Keys.NumPad7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num7] = 1; nNowKey = (int)KeyBoard.Key_Num7; break;
        case Keys.NumPad8: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num8] = 1; nNowKey = (int)KeyBoard.Key_Num8; break;
        case Keys.NumPad9: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num9] = 1; nNowKey = (int)KeyBoard.Key_Num9; break;
        case Keys.Add: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumPlus] = 1; nNowKey = (int)KeyBoard.Key_NumPlus; break;
        case Keys.NumPad4: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num4] = 1; nNowKey = (int)KeyBoard.Key_Num4; break;
        case Keys.NumPad5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num5] = 1; nNowKey = (int)KeyBoard.Key_Num5; break;
        case Keys.NumPad6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num6] = 1; nNowKey = (int)KeyBoard.Key_Num6; break;
        case Keys.NumPad1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num1] = 1; nNowKey = (int)KeyBoard.Key_Num1; break;
        case Keys.NumPad2: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num2] = 1; nNowKey = (int)KeyBoard.Key_Num2; break;
        case Keys.NumPad3: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num3] = 1; nNowKey = (int)KeyBoard.Key_Num3; break;
        //Enter
        case Keys.NumPad0: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num0] = 1; nNowKey = (int)KeyBoard.Key_Num0; break;
        case Keys.Decimal: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumPeriod] = 1; nNowKey = (int)KeyBoard.Key_NumPeriod; break;
        default: break;
      }
      for (int i = 0; i < CValueObject.g_KeySetting.Length; i++)
      {
        if (CValueObject.g_KeySetting[i] == nNowKey) { CValueObject.g_arrButton[i].BackColor = CValueObject.g_colorButton[i]; }
      }
    }

    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
      int nNowKey = -1;
      switch (e.KeyCode)
      {
        case Keys.Escape: CValueObject.g_KeyStatus[(int)KeyBoard.Key_ESC] = 0; nNowKey = (int)KeyBoard.Key_ESC; break;
        case Keys.F1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F1] = 0; nNowKey = (int)KeyBoard.Key_F1; break;
        case Keys.F2: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F2] = 0; nNowKey = (int)KeyBoard.Key_F2; break;
        case Keys.F3: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F3] = 0; nNowKey = (int)KeyBoard.Key_F3; break;
        case Keys.F4: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F4] = 0; nNowKey = (int)KeyBoard.Key_F4; break;
        case Keys.F5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F5] = 0; nNowKey = (int)KeyBoard.Key_F5; break;
        case Keys.F6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F6] = 0; nNowKey = (int)KeyBoard.Key_F6; break;
        case Keys.F7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F7] = 0; nNowKey = (int)KeyBoard.Key_F7; break;
        case Keys.F8: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F8] = 0; nNowKey = (int)KeyBoard.Key_F8; break;
        case Keys.F9: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F9] = 0; nNowKey = (int)KeyBoard.Key_F9; break;
        case Keys.F10: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F10] = 0; nNowKey = (int)KeyBoard.Key_F10; break;
        case Keys.F11: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F11] = 0; nNowKey = (int)KeyBoard.Key_F11; break;
        case Keys.F12: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F12] = 0; nNowKey = (int)KeyBoard.Key_F12; break;

        case Keys.PrintScreen: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PrintScreen] = 0; nNowKey = (int)KeyBoard.Key_PrintScreen; break;
        case Keys.Scroll: CValueObject.g_KeyStatus[(int)KeyBoard.Key_ScrollLock] = 0; nNowKey = (int)KeyBoard.Key_ScrollLock; break;
        case Keys.Pause: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PauseBreak] = 0; nNowKey = (int)KeyBoard.Key_PauseBreak; break;

        case Keys.Oemtilde: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Tilde] = 0; nNowKey = (int)KeyBoard.Key_Tilde; break;
        case Keys.D1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_1] = 0; nNowKey = (int)KeyBoard.Key_1; break;
        case Keys.D2: CValueObject.g_KeyStatus[(int)KeyBoard.Key_2] = 0; nNowKey = (int)KeyBoard.Key_2; break;
        case Keys.D3: CValueObject.g_KeyStatus[(int)KeyBoard.Key_3] = 0; nNowKey = (int)KeyBoard.Key_3; break;
        case Keys.D4: CValueObject.g_KeyStatus[(int)KeyBoard.Key_4] = 0; nNowKey = (int)KeyBoard.Key_4; break;
        case Keys.D5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_5] = 0; nNowKey = (int)KeyBoard.Key_5; break;
        case Keys.D6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_6] = 0; nNowKey = (int)KeyBoard.Key_6; break;
        case Keys.D7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_7] = 0; nNowKey = (int)KeyBoard.Key_7; break;
        case Keys.D8: CValueObject.g_KeyStatus[(int)KeyBoard.Key_8] = 0; nNowKey = (int)KeyBoard.Key_8; break;
        case Keys.D9: CValueObject.g_KeyStatus[(int)KeyBoard.Key_9] = 0; nNowKey = (int)KeyBoard.Key_9; break;
        case Keys.D0: CValueObject.g_KeyStatus[(int)KeyBoard.Key_0] = 0; nNowKey = (int)KeyBoard.Key_0; break;

        case Keys.Tab: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Tap] = 0; nNowKey = (int)KeyBoard.Key_Tap; break;
        case Keys.Q: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Q] = 0; nNowKey = (int)KeyBoard.Key_Q; break;
        case Keys.W: CValueObject.g_KeyStatus[(int)KeyBoard.Key_W] = 0; nNowKey = (int)KeyBoard.Key_W; break;
        case Keys.E: CValueObject.g_KeyStatus[(int)KeyBoard.Key_E] = 0; nNowKey = (int)KeyBoard.Key_E; break;
        case Keys.R: CValueObject.g_KeyStatus[(int)KeyBoard.Key_R] = 0; nNowKey = (int)KeyBoard.Key_R; break;
        case Keys.T: CValueObject.g_KeyStatus[(int)KeyBoard.Key_T] = 0; nNowKey = (int)KeyBoard.Key_T; break;
        case Keys.Y: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Y] = 0; nNowKey = (int)KeyBoard.Key_Y; break;
        case Keys.U: CValueObject.g_KeyStatus[(int)KeyBoard.Key_U] = 0; nNowKey = (int)KeyBoard.Key_U; break;
        case Keys.I: CValueObject.g_KeyStatus[(int)KeyBoard.Key_I] = 0; nNowKey = (int)KeyBoard.Key_I; break;
        case Keys.O: CValueObject.g_KeyStatus[(int)KeyBoard.Key_O] = 0; nNowKey = (int)KeyBoard.Key_O; break;
        case Keys.P: CValueObject.g_KeyStatus[(int)KeyBoard.Key_P] = 0; nNowKey = (int)KeyBoard.Key_P; break;
        case Keys.OemOpenBrackets: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LSquareBracket] = 0; nNowKey = (int)KeyBoard.Key_LSquareBracket; break;
        case Keys.Oem6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RSquareBracket] = 0; nNowKey = (int)KeyBoard.Key_RSquareBracket; break;
        case Keys.Oem5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_BackSlash] = 0; nNowKey = (int)KeyBoard.Key_BackSlash; break;

        case Keys.Capital: CValueObject.g_KeyStatus[(int)KeyBoard.Key_CapsLock] = 0; nNowKey = (int)KeyBoard.Key_CapsLock; break;
        case Keys.A: CValueObject.g_KeyStatus[(int)KeyBoard.Key_A] = 0; nNowKey = (int)KeyBoard.Key_A; break;
        case Keys.S: CValueObject.g_KeyStatus[(int)KeyBoard.Key_S] = 0; nNowKey = (int)KeyBoard.Key_S; break;
        case Keys.D: CValueObject.g_KeyStatus[(int)KeyBoard.Key_D] = 0; nNowKey = (int)KeyBoard.Key_D; break;
        case Keys.F: CValueObject.g_KeyStatus[(int)KeyBoard.Key_F] = 0; nNowKey = (int)KeyBoard.Key_F; break;
        case Keys.G: CValueObject.g_KeyStatus[(int)KeyBoard.Key_G] = 0; nNowKey = (int)KeyBoard.Key_G; break;
        case Keys.H: CValueObject.g_KeyStatus[(int)KeyBoard.Key_H] = 0; nNowKey = (int)KeyBoard.Key_H; break;
        case Keys.J: CValueObject.g_KeyStatus[(int)KeyBoard.Key_J] = 0; nNowKey = (int)KeyBoard.Key_J; break;
        case Keys.K: CValueObject.g_KeyStatus[(int)KeyBoard.Key_K] = 0; nNowKey = (int)KeyBoard.Key_K; break;
        case Keys.L: CValueObject.g_KeyStatus[(int)KeyBoard.Key_L] = 0; nNowKey = (int)KeyBoard.Key_L; break;
        case Keys.Oem1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Semicolon] = 0; nNowKey = (int)KeyBoard.Key_Semicolon; break;
        case Keys.Oem7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Apostrophe] = 0; nNowKey = (int)KeyBoard.Key_Apostrophe; break;
        case Keys.Return: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Enter] = 0; nNowKey = (int)KeyBoard.Key_Enter; break;

        //case Keys.ShiftKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LShift] = 0; CValueObject.g_KeyStatus[(int)KeyBoard.Key_RShift] = 0; break; 
        case Keys.LShiftKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LShift] = 0; nNowKey = (int)KeyBoard.Key_LShift; break;
        case Keys.Z: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Z] = 0; nNowKey = (int)KeyBoard.Key_Z; break;
        case Keys.X: CValueObject.g_KeyStatus[(int)KeyBoard.Key_X] = 0; nNowKey = (int)KeyBoard.Key_X; break;
        case Keys.C: CValueObject.g_KeyStatus[(int)KeyBoard.Key_C] = 0; nNowKey = (int)KeyBoard.Key_C; break;
        case Keys.V: CValueObject.g_KeyStatus[(int)KeyBoard.Key_V] = 0; nNowKey = (int)KeyBoard.Key_V; break;
        case Keys.B: CValueObject.g_KeyStatus[(int)KeyBoard.Key_B] = 0; nNowKey = (int)KeyBoard.Key_B; break;
        case Keys.N: CValueObject.g_KeyStatus[(int)KeyBoard.Key_N] = 0; nNowKey = (int)KeyBoard.Key_N; break;
        case Keys.M: CValueObject.g_KeyStatus[(int)KeyBoard.Key_M] = 0; nNowKey = (int)KeyBoard.Key_M; break;
        case Keys.Oemcomma: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Comma] = 0; nNowKey = (int)KeyBoard.Key_Comma; break;
        case Keys.OemPeriod: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Period] = 0; nNowKey = (int)KeyBoard.Key_Period; break;
        case Keys.OemQuestion: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Slash] = 0; nNowKey = (int)KeyBoard.Key_Slash; break;

        //case Keys.ControlKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LCtrl] = 0; CValueObject.g_KeyStatus[(int)KeyBoard.Key_RCtrl] = 0; break;
        case Keys.LControlKey: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LCtrl] = 0; nNowKey = (int)KeyBoard.Key_LCtrl; break;
        case Keys.LWin: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LWin] = 0; nNowKey = (int)KeyBoard.Key_LWin; break;
        case Keys.Space: CValueObject.g_KeyStatus[(int)KeyBoard.Key_SpaceBar] = 0; nNowKey = (int)KeyBoard.Key_SpaceBar; break;
        case Keys.KanaMode: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RAlt] = 0; nNowKey = (int)KeyBoard.Key_RAlt; break;
        //FN key
        case Keys.HanjaMode: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RCtrl] = 0; nNowKey = (int)KeyBoard.Key_RCtrl; break;

        case Keys.Insert: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Insert] = 0; nNowKey = (int)KeyBoard.Key_Insert; break;
        case Keys.Home: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Home] = 0; nNowKey = (int)KeyBoard.Key_Home; break;
        case Keys.PageUp: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PageUp] = 0; nNowKey = (int)KeyBoard.Key_PageUp; break;
        case Keys.Delete: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Delete] = 0; nNowKey = (int)KeyBoard.Key_Delete; break;
        case Keys.End: CValueObject.g_KeyStatus[(int)KeyBoard.Key_End] = 0; nNowKey = (int)KeyBoard.Key_End; break;
        case Keys.PageDown: CValueObject.g_KeyStatus[(int)KeyBoard.Key_PageDown] = 0; nNowKey = (int)KeyBoard.Key_PageDown; break;

        case Keys.Up: CValueObject.g_KeyStatus[(int)KeyBoard.Key_UpArrow] = 0; nNowKey = (int)KeyBoard.Key_UpArrow; break;
        case Keys.Left: CValueObject.g_KeyStatus[(int)KeyBoard.Key_LeftArrow] = 0; nNowKey = (int)KeyBoard.Key_LeftArrow; break;
        case Keys.Down: CValueObject.g_KeyStatus[(int)KeyBoard.Key_DownArrow] = 0; nNowKey = (int)KeyBoard.Key_DownArrow; break;
        case Keys.Right: CValueObject.g_KeyStatus[(int)KeyBoard.Key_RightArrow] = 0; nNowKey = (int)KeyBoard.Key_RightArrow; break;

        case Keys.NumLock: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumberLock] = 0; nNowKey = (int)KeyBoard.Key_NumberLock; break;
        case Keys.Divide: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumSlash] = 0; nNowKey = (int)KeyBoard.Key_NumSlash; break;
        case Keys.Multiply: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumAsterisk] = 0; nNowKey = (int)KeyBoard.Key_NumAsterisk; break;
        case Keys.Subtract: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumHyphen] = 0; nNowKey = (int)KeyBoard.Key_NumHyphen; break;
        case Keys.NumPad7: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num7] = 0; nNowKey = (int)KeyBoard.Key_Num7; break;
        case Keys.NumPad8: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num8] = 0; nNowKey = (int)KeyBoard.Key_Num8; break;
        case Keys.NumPad9: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num9] = 0; nNowKey = (int)KeyBoard.Key_Num9; break;
        case Keys.Add: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumPlus] = 0; nNowKey = (int)KeyBoard.Key_NumPlus; break;
        case Keys.NumPad4: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num4] = 0; nNowKey = (int)KeyBoard.Key_Num4; break;
        case Keys.NumPad5: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num5] = 0; nNowKey = (int)KeyBoard.Key_Num5; break;
        case Keys.NumPad6: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num6] = 0; nNowKey = (int)KeyBoard.Key_Num6; break;
        case Keys.NumPad1: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num1] = 0; nNowKey = (int)KeyBoard.Key_Num1; break;
        case Keys.NumPad2: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num2] = 0; nNowKey = (int)KeyBoard.Key_Num2; break;
        case Keys.NumPad3: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num3] = 0; nNowKey = (int)KeyBoard.Key_Num3; break;
        //Enter
        case Keys.NumPad0: CValueObject.g_KeyStatus[(int)KeyBoard.Key_Num0] = 0; nNowKey = (int)KeyBoard.Key_Num0; break;
        case Keys.Decimal: CValueObject.g_KeyStatus[(int)KeyBoard.Key_NumPeriod] = 0; nNowKey = (int)KeyBoard.Key_NumPeriod; break;
        default: break;
      }
      if (nNowKey != -1)
      {
        for (int i = 0; i < CValueObject.g_KeySetting.Length; i++)
        {
          if (CValueObject.g_KeySetting[i] == nNowKey) { CValueObject.g_arrButton[i].BackColor = System.Drawing.Color.FromArgb(255, 255, 255); }
        }
      }
    }

    private void btn_1_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[0]] = 1;
      CValueObject.g_arrButton[0].BackColor = CValueObject.g_colorButton[0];
    }

    private void btn_1_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[0]] = 0;
      CValueObject.g_arrButton[0].BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
    }

    private void btn_2_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[1]] = 1;
    }

    private void btn_2_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[1]] = 0;
    }

    private void btn_3_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[2]] = 1;
    }

    private void btn_3_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[2]] = 0;
    }

    private void btn_4_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[3]] = 1;
    }

    private void btn_4_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[3]] = 0;
    }

    private void btn_5_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[4]] = 1;
    }

    private void btn_5_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[4]] = 0;
    }

    private void btn_6_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[5]] = 1;
    }

    private void btn_6_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[5]] = 0;
    }

    private void btn_7_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[6]] = 1;
    }

    private void btn_7_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[6]] = 0;
    }

    private void btn_8_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[7]] = 1;
    }

    private void btn_8_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[7]] = 0;
    }

    private void btn_9_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[8]] = 1;
    }

    private void btn_9_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[8]] = 0;
    }

    private void btn_10_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[9]] = 1;
    }

    private void btn_10_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[9]] = 0;
    }

    private void btn_11_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[10]] = 1;
    }

    private void btn_11_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[10]] = 0;
    }

    private void btn_12_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[11]] = 1;
    }

    private void btn_12_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[11]] = 0;
    }

    private void btn_13_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[12]] = 1;
    }

    private void btn_13_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[12]] = 0;
    }

    private void btn_14_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[13]] = 1;
    }

    private void btn_14_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[13]] = 0;
    }

    private void btn_15_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[14]] = 1;
    }

    private void btn_15_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[14]] = 0;
    }

    private void btn_16_MouseDown(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[15]] = 1;
    }

    private void btn_16_MouseUp(object sender, MouseEventArgs e)
    {
      CValueObject.g_KeyStatus[CValueObject.g_KeySetting[15]] = 0;
    }
  }
}
