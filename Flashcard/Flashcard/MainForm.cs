namespace Flashcard
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private Card _currendCard;
        private Slot _slot1 = new Slot();
        private Slot _slot2 = new Slot();
        private Slot _slot3 = new Slot();
        private List<Slot> _slotList = new List<Slot>();
        private int _currentSlotID = 1;

        private void MainForm_Load(object sender, EventArgs e)
        {
            
            _slot1.SlotID = 1;
            _slot1.CardList = new List<Card>();
            _slotList.Add(_slot1);
            _slot2.SlotID = 2;
            _slot2.CardList = new List<Card>();
            _slotList.Add(_slot2);
            _slot3.SlotID = 3;
            _slot3.CardList = new List<Card>();
            _slotList.Add(_slot3);

            _cbSlotNumber.Items.Add(_slot1.SlotID.ToString());
            _cbSlotNumber.Items.Add(_slot2.SlotID.ToString());
            _cbSlotNumber.Items.Add(_slot3.SlotID.ToString());
            _cbSlotNumber.SelectedIndex = 0;
            //reading data from data.txt and putting it into Cards
            ReadDataFromFile(_slot1.CardList);
            
            //printing data to interface
            FillTranslationList(_slot1.CardList);
            SetRandomWordToTranslate(_slot1.CardList);
        }

        private void ReadDataFromFile(List<Card> listOfCards)
        {
            string[] fileInputData = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() + "/data.txt");

            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",");
                listOfCards.Add(new Card(dataLine[0], dataLine[1]));
            }
        }

        //print a random ger word of a list of cards to the lblWordToTranslate control and set its card to the _currentCard
        private void SetRandomWordToTranslate(List<Card> listOfCards)
        {
            Random chooseRandomWord = new Random();
            int randomWordIndex = Convert.ToInt32(chooseRandomWord.NextInt64(0, listOfCards.Count));
            _currendCard = listOfCards[randomWordIndex];
            _lblWordToTranslate.Text = _currendCard.GermanWord;    
        }

        private void BtnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            SetRandomWordToTranslate(_slot1.CardList);
        }

        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void FillTranslationList(List<Card> listOfCards)
        {
            _lbTranslationList.Items.Clear();
            foreach (Card card in listOfCards)
            {
                _lbTranslationList.Items.Add(card.EnglishWord);
            } 
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (_btnSubmit.Text == "Bestätigen")
            {
                if (_lbTranslationList.SelectedItem.ToString() == _currendCard.EnglishWord)
                {
                    _lblValidation.Text = "Korrekt";
                }
                else
                {
                    _lblValidation.Text = "Falsch! " + _currendCard.EnglishWord + " wäre richtig gewesen";
                }
                _btnSubmit.Text = "Weiter";
            }
            else
            {
                _lblValidation.Text = "";
                _lbTranslationList.ClearSelected();
                _btnSubmit.Text = "Bestätigen";
                SetRandomWordToTranslate(_slot1.CardList);
            }
        }

        private void WriteCardsToFile(string path)
        {
            //Writing all GermanWord and EnglishWord of all Cards into data.txt
            System.IO.File.WriteAllText(path, "");
            string[] fileOutputData = new string[_lbTranslationList.Items.Count];
            for (int i = 0; i < fileOutputData.Length; i++)
            {
                Card selectedCard = _slot1.CardList.ElementAt(i);
                fileOutputData[i] = selectedCard.GermanWord + "," + selectedCard.EnglishWord;
            }
            System.IO.File.WriteAllLines(path, fileOutputData);
        }
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            WriteCardsToFile(Directory.GetCurrentDirectory() + "/data.txt");            
        }

        private void CbSlotNumberSelectIndexChanged(object sender, EventArgs e)
        {
            
            FillTranslationList(_slotList.ElementAt(Int32.Parse(_cbSlotNumber.SelectedItem.ToString())-1).CardList);
        }
    }
}