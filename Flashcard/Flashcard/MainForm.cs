namespace Flashcard
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();

            
        }

        private List<Card> _cardList = new List<Card>();
        private Card _currendCard;

        private void MainForm_Load(object sender, EventArgs e)
        {

             
            //reading data from data.txt and putting it into Cards
            string[] fileInputData = System.IO.File.ReadAllLines(Directory.GetCurrentDirectory() +"/data.txt");
            
            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",");
                _cardList.Add(new Card(dataLine[0], dataLine[1]));
            }
            
            //printing data to interface
            FillTranslationList(_cardList);
            SetRandomWordToTranslate(_cardList);
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
            SetRandomWordToTranslate(_cardList);
        }

        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void FillTranslationList(List<Card> listOfCards)
        {
            _lbTranslationList.Items.Clear();
            //printing data to interce
            foreach (Card card in listOfCards)
            {
                _lbTranslationList.Items.Add(card.EnglishWord);
            } 
        }
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
                SetRandomWordToTranslate(_cardList);
            }
        }

        private void WriteCardsToFile()
        {
            //Writing all GermanWord and EnglishWord of all Cards into data.txt
            System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + "/data.txt", "");
            string[] fileOutputData = new string[_lbTranslationList.Items.Count];
            for (int i = 0; i < fileOutputData.Length; i++)
            {
                Card selectedCard = _cardList.ElementAt(i);
                fileOutputData[i] = selectedCard.GermanWord + "," + selectedCard.EnglishWord;

            }
            System.IO.File.WriteAllLines(Directory.GetCurrentDirectory() + "/data.txt", fileOutputData);
        }
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            WriteCardsToFile();            
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        

        
    }
}