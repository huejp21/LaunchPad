using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaunchPad
{
  
  public partial class KeyBoardForm : Form
  {
    int m_KeySet = 0;
    string m_KeyString = "";
    public static string[] m_strFirstLineKey = 
    {
    "ESC",
    "F1",
    "F2",
    "F3",
    "F4",
    "F5",
    "F6",
    "F7",
    "F8",
    "F9",
    "F10",
    "F11",
    "F12"
    };
    public static string[] m_strSecondLineKey = 
    {
    "`",
    "1",
    "2",
    "3",
    "4",
    "5",
    "6",
    "7",
    "8",
    "9",
    "0",
    "-",
    "=",
    "BS"
    };

    public static string[] m_strThirdLineKey = 
    {  
    "Tap",
    "Q",
    "W",
    "E",
    "R",
    "T",
    "Y",
    "U",
    "I",
    "O",
    "P",
    "[",
    "]",
    "\\"
    };
    public static string[] m_strFourthLineKey = 
    {
    "CapsLock",
    "A",
    "S",
    "D",
    "F",
    "G",
    "H",
    "J",
    "K",
    "L",
    ";",
    "'",
    "Enter"
    };
    public static string[] m_strFifthLineKey = 
    {
    "LShift",
    "Z",
    "X",
    "C",
    "V",
    "B",
    "N",
    "M",
    ",",
    ".",
    "/",
    "RShift"
    };
    public static string[] m_strSixthLineKey = 
    {
    "LCtrl",
    "LWin",
    "LAlt",
    "Space",
    "RAlt",
    "FN",
    "RCtrl"
    };
    public static string[] m_strFunctionKey1 = 
    { 
    "PrintScreen",
    "ScrollLock",
    "PuaseBreak",

    "Insert",
    "Home",
    "PageUp",
    "Delete",
    "End",
    "PageDown"
    };
    public static string[] m_strFunctionKey2 = 
    { 
    "▲",
    "◀",
    "▼",
    "▶"
    };
    public static string[] m_strNumKey = 
    { 
    "NumberLock",
    "/",
    "*",
    "-",
    "N7",
    "N8",
    "N9",
    "+",
    "N4",
    "N5",
    "N6",
    "N1",
    "N2",
    "N3",
    "NEnter",
    "N0",
    "."
    };

    public static int m_nCountAllKey =
      m_strFirstLineKey.Length +
      m_strSecondLineKey.Length +
      m_strThirdLineKey.Length +
      m_strFourthLineKey.Length +
      m_strFifthLineKey.Length +
      m_strSixthLineKey.Length +
      m_strFunctionKey1.Length +
      m_strFunctionKey2.Length +
      m_strNumKey.Length;

    public Control[] m_arrKeyButton = new Control[m_nCountAllKey];

    public KeyBoardForm()
    {
      InitializeComponent();
    }

    private void KeyBoardForm_Load(object sender, EventArgs e)
    {
      //Setup Form
      this.KeyPreview = true;

      //Values
      int nKeySize = 40;

      int nNowIndex = 0;
      int nGap = (600 - (40 * m_strFirstLineKey.Length)) / 3;
      int nLocation = 0;
      int nSize = 0;
      int nHSize = 0;
      int nHieght = 0;


      //FirstLine
      for (int i = 0; i < m_strFirstLineKey.Length; i++)
      {
        if (i == 1 || i == 5 || i == 9) { nLocation += nGap; }
        m_arrKeyButton[i] = new Button();
        m_arrKeyButton[i].Name = string.Format("btn_{0}", m_strFirstLineKey[i]);
        m_arrKeyButton[i].Parent = this;
        m_arrKeyButton[i].Location = new Point(nLocation, 0);
        m_arrKeyButton[i].Size = new Size(nKeySize, nKeySize);
        m_arrKeyButton[i].Text = m_strFirstLineKey[i];
        m_arrKeyButton[i].Click += new EventHandler(Click_Button);
        nLocation += 40;
      }
      nNowIndex += m_strFirstLineKey.Length;

      //SecondLine
      nGap = 600 - (nKeySize * m_strSecondLineKey.Length);
      nLocation = 0;
      for (int i = nNowIndex; i < nNowIndex + m_strSecondLineKey.Length; i++)
      {
        m_arrKeyButton[i] = new Button();
        m_arrKeyButton[i].Name = string.Format("btn_{0}", m_strSecondLineKey[i - nNowIndex]);
        m_arrKeyButton[i].Parent = this;
        m_arrKeyButton[i].Location = new Point((i - nNowIndex) * nKeySize, 80);
        if ((i - nNowIndex) == 13) { m_arrKeyButton[i].Size = new Size(nKeySize + nGap, nKeySize); }
        else { m_arrKeyButton[i].Size = new Size(nKeySize, nKeySize); }
        m_arrKeyButton[i].Text = m_strSecondLineKey[i - nNowIndex];
        m_arrKeyButton[i].Click += new EventHandler(Click_Button);
        nLocation += 40;
      }
      nNowIndex += m_strSecondLineKey.Length;

      //ThirdLine
      nGap = (600 - (nKeySize * m_strThirdLineKey.Length - 1))/2;
      nLocation = 0;
      nSize = 0;
      for (int i = nNowIndex; i < nNowIndex + m_strThirdLineKey.Length; i++)
      {
        if ((i - nNowIndex) == 0 || (i - nNowIndex) == 13) { nSize = nKeySize + nGap; }
        else { nSize = nKeySize; }
        m_arrKeyButton[i] = new Button();
        m_arrKeyButton[i].Name = string.Format("btn_{0}", m_strThirdLineKey[i - nNowIndex]);
        m_arrKeyButton[i].Parent = this;
        m_arrKeyButton[i].Location = new Point(nLocation, 120);
        m_arrKeyButton[i].Size = new Size(nSize, nKeySize);
        m_arrKeyButton[i].Text = m_strThirdLineKey[i - nNowIndex];
        m_arrKeyButton[i].Click += new EventHandler(Click_Button);
        nLocation += nSize;
      }
      nNowIndex += m_strThirdLineKey.Length;

      //FourthLine
      nGap = (600 - (nKeySize * m_strFourthLineKey.Length - 1)) / 2;
      nLocation = 0;
      nSize = 0;
      for (int i = nNowIndex; i < nNowIndex + m_strFourthLineKey.Length; i++)
      {
        if ((i - nNowIndex) == 0 || (i - nNowIndex) == 12) { nSize = nKeySize + nGap; }
        else { nSize = nKeySize; }
        m_arrKeyButton[i] = new Button();
        m_arrKeyButton[i].Name = string.Format("btn_{0}", m_strFourthLineKey[i - nNowIndex]);
        m_arrKeyButton[i].Parent = this;
        m_arrKeyButton[i].Location = new Point(nLocation, 160);
        m_arrKeyButton[i].Size = new Size(nSize, nKeySize);
        m_arrKeyButton[i].Text = m_strFourthLineKey[i - nNowIndex];
        m_arrKeyButton[i].Click += new EventHandler(Click_Button);
        nLocation += nSize;
      }
      nNowIndex += m_strFourthLineKey.Length;

      //FifthLine
      nGap = (600 - (nKeySize * m_strFifthLineKey.Length - 1)) / 2;
      nLocation = 0;
      nSize = 0;
      for (int i = nNowIndex; i < nNowIndex + m_strFifthLineKey.Length; i++)
      {
        if ((i - nNowIndex) == 0 || (i - nNowIndex) == 11) { nSize = nKeySize + nGap; }
        else { nSize = nKeySize; }
        m_arrKeyButton[i] = new Button();
        m_arrKeyButton[i].Name = string.Format("btn_{0}", m_strFifthLineKey[i - nNowIndex]);
        m_arrKeyButton[i].Parent = this;
        m_arrKeyButton[i].Location = new Point(nLocation, 200);
        m_arrKeyButton[i].Size = new Size(nSize, nKeySize);
        m_arrKeyButton[i].Text = m_strFifthLineKey[i - nNowIndex];
        m_arrKeyButton[i].Click += new EventHandler(Click_Button);
        nLocation += nSize;
      }
      nNowIndex += m_strFifthLineKey.Length;

      //SixLine
      nGap = 600 - (nKeySize * m_strSixthLineKey.Length - 1);
      nLocation = 0;
      nSize = 0;
      for (int i = nNowIndex; i < nNowIndex + m_strSixthLineKey.Length; i++)
      {
        if ((i - nNowIndex) == 3) { nSize = nKeySize + nGap; }
        else { nSize = nKeySize; }
        m_arrKeyButton[i] = new Button();
        m_arrKeyButton[i].Name = string.Format("btn_{0}", m_strSixthLineKey[i - nNowIndex]);
        m_arrKeyButton[i].Parent = this;
        m_arrKeyButton[i].Location = new Point(nLocation, 240);
        m_arrKeyButton[i].Size = new Size(nSize, nKeySize);
        m_arrKeyButton[i].Text = m_strSixthLineKey[i - nNowIndex];
        m_arrKeyButton[i].Click += new EventHandler(Click_Button);
        nLocation += nSize;
      }
      nNowIndex += m_strSixthLineKey.Length;

      //Founction Line
      nGap = 0;
      nLocation = 640;
      nSize = 0;
      nHieght = 0;
      for (int i = 0; i < m_strFunctionKey1.Length; i++)
      {
        if (i == 3) { nHieght = 80; nLocation = 640; }
        if (i == 6) { nHieght = 120; nLocation = 640; }
        m_arrKeyButton[nNowIndex + i] = new Button();
        m_arrKeyButton[nNowIndex + i].Name = string.Format("btn_{0}", m_strFunctionKey1[i]);
        m_arrKeyButton[nNowIndex + i].Parent = this;
        m_arrKeyButton[nNowIndex + i].Location = new Point(nLocation, nHieght);
        m_arrKeyButton[nNowIndex + i].Size = new Size(nKeySize, nKeySize);
        m_arrKeyButton[nNowIndex + i].Text = m_strFunctionKey1[i];
        m_arrKeyButton[nNowIndex + i].Click += new EventHandler(Click_Button);
        nLocation += nKeySize;
      }
      nNowIndex += m_strFunctionKey1.Length;

      //Arrow Line
      nGap = 0;
      nLocation = 640;
      nSize = 0;
      nHieght = 0;
      for (int i = 0; i < m_strFunctionKey2.Length; i++)
      {
        if (i == 0) { nHieght = 200; nLocation = 640 + 40; }
        if (i == 1) { nHieght = 240; nLocation = 640; }
        m_arrKeyButton[nNowIndex + i] = new Button();
        m_arrKeyButton[nNowIndex + i].Name = string.Format("btn_{0}", m_strFunctionKey2[i]);
        m_arrKeyButton[nNowIndex + i].Parent = this;
        m_arrKeyButton[nNowIndex + i].Location = new Point(nLocation, nHieght);
        m_arrKeyButton[nNowIndex + i].Size = new Size(nKeySize, nKeySize);
        m_arrKeyButton[nNowIndex + i].Text = m_strFunctionKey2[i];
        m_arrKeyButton[nNowIndex + i].Click += new EventHandler(Click_Button);
        nLocation += nKeySize;
      }
      nNowIndex += m_strFunctionKey2.Length;

      //NumberPad
      nGap = 0;
      nLocation = 800;
      nSize = nKeySize;
      nHieght = 80;
      nHSize = nKeySize;
      for (int i = 0; i < m_strNumKey.Length; i++)
      {
        nSize = nKeySize;
        nHSize = nKeySize;
        if (i == 0) { nHieght = 80; nLocation = 800; }
        if (i == 4) { nHieght = 120; nLocation = 800; }
        if (i == 8) { nHieght = 160; nLocation = 800; }
        if (i == 11) { nHieght = 200; nLocation = 800; }
        if (i == 15) { nHieght = 240; nLocation = 800; }
        if (i == 7) { nHSize = 80; }
        if (i == 14) { nHSize = 80; }
        if (i == 15) { nSize = 80; }
        m_arrKeyButton[nNowIndex + i] = new Button();
        m_arrKeyButton[nNowIndex + i].Name = string.Format("btn_{0}", m_strNumKey[i]);
        m_arrKeyButton[nNowIndex + i].Parent = this;
        m_arrKeyButton[nNowIndex + i].Location = new Point(nLocation, nHieght);
        m_arrKeyButton[nNowIndex + i].Size = new Size(nSize, nHSize);
        m_arrKeyButton[nNowIndex + i].Text = m_strNumKey[i];
        m_arrKeyButton[nNowIndex + i].Click += new EventHandler(Click_Button);
        nLocation += nSize;
      }
      nNowIndex += m_strNumKey.Length;
    }

    public void Click_Button(object sender, EventArgs e)
    {
      Control ctl = sender as Control;
      if (ctl != null)
      {
        m_KeyString = ctl.Text;
        if (ctl.Text.Equals("ESC")) { m_KeySet = (int)KeyBoard.Key_ESC; }
        if (ctl.Text.Equals("F1")) { m_KeySet = (int)KeyBoard.Key_F1; }
        if (ctl.Text.Equals("F2")) { m_KeySet = (int)KeyBoard.Key_F2; }
        if (ctl.Text.Equals("F3")) { m_KeySet = (int)KeyBoard.Key_F3; }
        if (ctl.Text.Equals("F4")) { m_KeySet = (int)KeyBoard.Key_F4; }
        if (ctl.Text.Equals("F5")) { m_KeySet = (int)KeyBoard.Key_F5; }
        if (ctl.Text.Equals("F6")) { m_KeySet = (int)KeyBoard.Key_F6; }
        if (ctl.Text.Equals("F7")) { m_KeySet = (int)KeyBoard.Key_F7; }
        if (ctl.Text.Equals("F8")) { m_KeySet = (int)KeyBoard.Key_F8; }
        if (ctl.Text.Equals("F9")) { m_KeySet = (int)KeyBoard.Key_F9; }
        if (ctl.Text.Equals("F10")) { m_KeySet = (int)KeyBoard.Key_F10; }
        if (ctl.Text.Equals("F11")) { m_KeySet = (int)KeyBoard.Key_F11; }
        if (ctl.Text.Equals("F12")) { m_KeySet = (int)KeyBoard.Key_F12; }
        if (ctl.Text.Equals("`")) { m_KeySet = (int)KeyBoard.Key_Tilde; }
        if (ctl.Text.Equals("1")) { m_KeySet = (int)KeyBoard.Key_1; }
        if (ctl.Text.Equals("2")) { m_KeySet = (int)KeyBoard.Key_2; }
        if (ctl.Text.Equals("3")) { m_KeySet = (int)KeyBoard.Key_3; }
        if (ctl.Text.Equals("4")) { m_KeySet = (int)KeyBoard.Key_4; }
        if (ctl.Text.Equals("5")) { m_KeySet = (int)KeyBoard.Key_5; }
        if (ctl.Text.Equals("6")) { m_KeySet = (int)KeyBoard.Key_6; }
        if (ctl.Text.Equals("7")) { m_KeySet = (int)KeyBoard.Key_7; }
        if (ctl.Text.Equals("8")) { m_KeySet = (int)KeyBoard.Key_8; }
        if (ctl.Text.Equals("9")) { m_KeySet = (int)KeyBoard.Key_9; }
        if (ctl.Text.Equals("0")) { m_KeySet = (int)KeyBoard.Key_0; }
        if (ctl.Text.Equals("-")) { m_KeySet = (int)KeyBoard.Key_Hyphen; }
        if (ctl.Text.Equals("=")) { m_KeySet = (int)KeyBoard.Key_Plus; }
        if (ctl.Text.Equals("BS")) { m_KeySet = (int)KeyBoard.Key_BackSpace; }
        if (ctl.Text.Equals("Tap")) { m_KeySet = (int)KeyBoard.Key_Tap; }
        if (ctl.Text.Equals("Q")) { m_KeySet = (int)KeyBoard.Key_Q; }
        if (ctl.Text.Equals("W")) { m_KeySet = (int)KeyBoard.Key_W; }
        if (ctl.Text.Equals("E")) { m_KeySet = (int)KeyBoard.Key_E; }
        if (ctl.Text.Equals("R")) { m_KeySet = (int)KeyBoard.Key_R; }
        if (ctl.Text.Equals("T")) { m_KeySet = (int)KeyBoard.Key_T; }
        if (ctl.Text.Equals("Y")) { m_KeySet = (int)KeyBoard.Key_Y; }
        if (ctl.Text.Equals("U")) { m_KeySet = (int)KeyBoard.Key_U; }
        if (ctl.Text.Equals("I")) { m_KeySet = (int)KeyBoard.Key_I; }
        if (ctl.Text.Equals("O")) { m_KeySet = (int)KeyBoard.Key_O; }
        if (ctl.Text.Equals("P")) { m_KeySet = (int)KeyBoard.Key_P; }
        if (ctl.Text.Equals("[")) { m_KeySet = (int)KeyBoard.Key_LSquareBracket; }
        if (ctl.Text.Equals("]")) { m_KeySet = (int)KeyBoard.Key_RSquareBracket; }
        if (ctl.Text.Equals("\\")) { m_KeySet = (int)KeyBoard.Key_BackSlash; }
        if (ctl.Text.Equals("CapsLock")) { m_KeySet = (int)KeyBoard.Key_CapsLock; }
        if (ctl.Text.Equals("A")) { m_KeySet = (int)KeyBoard.Key_A; }
        if (ctl.Text.Equals("S")) { m_KeySet = (int)KeyBoard.Key_S; }
        if (ctl.Text.Equals("D")) { m_KeySet = (int)KeyBoard.Key_D; }
        if (ctl.Text.Equals("F")) { m_KeySet = (int)KeyBoard.Key_F; }
        if (ctl.Text.Equals("G")) { m_KeySet = (int)KeyBoard.Key_G; }
        if (ctl.Text.Equals("H")) { m_KeySet = (int)KeyBoard.Key_H; }
        if (ctl.Text.Equals("J")) { m_KeySet = (int)KeyBoard.Key_J; }
        if (ctl.Text.Equals("K")) { m_KeySet = (int)KeyBoard.Key_K; }
        if (ctl.Text.Equals("L")) { m_KeySet = (int)KeyBoard.Key_L; }
        if (ctl.Text.Equals(";")) { m_KeySet = (int)KeyBoard.Key_Semicolon; }
        if (ctl.Text.Equals("'")) { m_KeySet = (int)KeyBoard.Key_Apostrophe; }
        if (ctl.Text.Equals("Enter")) { m_KeySet = (int)KeyBoard.Key_Enter; }
        if (ctl.Text.Equals("LShift")) { m_KeySet = (int)KeyBoard.Key_LShift; }
        if (ctl.Text.Equals("Z")) { m_KeySet = (int)KeyBoard.Key_Z; }
        if (ctl.Text.Equals("X")) { m_KeySet = (int)KeyBoard.Key_X; }
        if (ctl.Text.Equals("C")) { m_KeySet = (int)KeyBoard.Key_C; }
        if (ctl.Text.Equals("V")) { m_KeySet = (int)KeyBoard.Key_V; }
        if (ctl.Text.Equals("B")) { m_KeySet = (int)KeyBoard.Key_B; }
        if (ctl.Text.Equals("N")) { m_KeySet = (int)KeyBoard.Key_N; }
        if (ctl.Text.Equals("M")) { m_KeySet = (int)KeyBoard.Key_M; }
        if (ctl.Text.Equals(",")) { m_KeySet = (int)KeyBoard.Key_Comma; }
        if (ctl.Text.Equals(".")) { m_KeySet = (int)KeyBoard.Key_Period; }
        if (ctl.Text.Equals("/")) { m_KeySet = (int)KeyBoard.Key_Slash; }
        if (ctl.Text.Equals("RShift")) { m_KeySet = (int)KeyBoard.Key_RShift; }
        if (ctl.Text.Equals("LCtrl")) { m_KeySet = (int)KeyBoard.Key_LCtrl; }
        if (ctl.Text.Equals("LWin")) { m_KeySet = (int)KeyBoard.Key_LWin; }
        if (ctl.Text.Equals("LAlt")) { m_KeySet = (int)KeyBoard.Key_LAlt; }
        if (ctl.Text.Equals("Space")) { m_KeySet = (int)KeyBoard.Key_SpaceBar; }
        if (ctl.Text.Equals("RAlt")) { m_KeySet = (int)KeyBoard.Key_RAlt; }
        if (ctl.Text.Equals("FN")) { m_KeySet = (int)KeyBoard.Key_FN; }
        if (ctl.Text.Equals("RCtrl")) { m_KeySet = (int)KeyBoard.Key_RCtrl; }
        if (ctl.Text.Equals("▲")) { m_KeySet = (int)KeyBoard.Key_UpArrow; }
        if (ctl.Text.Equals("◀")) { m_KeySet = (int)KeyBoard.Key_LeftArrow; }
        if (ctl.Text.Equals("▼")) { m_KeySet = (int)KeyBoard.Key_DownArrow; }
        if (ctl.Text.Equals("▶")) { m_KeySet = (int)KeyBoard.Key_RightArrow; }
        if (ctl.Text.Equals("NumberLock")) { m_KeySet = (int)KeyBoard.Key_NumberLock; }
        if (ctl.Text.Equals("/")) { m_KeySet = (int)KeyBoard.Key_NumSlash; }
        if (ctl.Text.Equals("*")) { m_KeySet = (int)KeyBoard.Key_NumAsterisk; }
        if (ctl.Text.Equals("-")) { m_KeySet = (int)KeyBoard.Key_NumHyphen; }
        if (ctl.Text.Equals("N7")) { m_KeySet = (int)KeyBoard.Key_Num7; }
        if (ctl.Text.Equals("N8")) { m_KeySet = (int)KeyBoard.Key_Num8; }
        if (ctl.Text.Equals("N9")) { m_KeySet = (int)KeyBoard.Key_Num9; }
        if (ctl.Text.Equals("+")) { m_KeySet = (int)KeyBoard.Key_NumPlus; }
        if (ctl.Text.Equals("N4")) { m_KeySet = (int)KeyBoard.Key_Num4; }
        if (ctl.Text.Equals("N5")) { m_KeySet = (int)KeyBoard.Key_Num5; }
        if (ctl.Text.Equals("N6")) { m_KeySet = (int)KeyBoard.Key_Num6; }
        if (ctl.Text.Equals("N1")) { m_KeySet = (int)KeyBoard.Key_Num1; }
        if (ctl.Text.Equals("N2")) { m_KeySet = (int)KeyBoard.Key_Num2; }
        if (ctl.Text.Equals("N3")) { m_KeySet = (int)KeyBoard.Key_Num3; }
        if (ctl.Text.Equals("NEnter")) { m_KeySet = (int)KeyBoard.Key_NumEnter; }
        if (ctl.Text.Equals("N0")) { m_KeySet = (int)KeyBoard.Key_Num0; }
        if (ctl.Text.Equals(".")) { m_KeySet = (int)KeyBoard.Key_NumPeriod; }
        this.Close();
      }
    }

    public void SetKey(ref int nBuffer, ref string strBuffer)
    {
      nBuffer = m_KeySet;
      strBuffer = m_KeyString;
    }
  }
}
