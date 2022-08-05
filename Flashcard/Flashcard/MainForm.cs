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
            string[] fileInputData = System.IO.File.ReadAllLines(@"D:\Projects\DigitalFlashcard\Flashcard\Flashcard\data.txt");
            
            for (int i = 0; i < fileInputData.Length; i++)
            {
                string[] dataLine = fileInputData[i].Split(",");
                _cardList.Add(new Card(dataLine[0], dataLine[1]));
            }
            
            //printing data to interface
            fillTranslationList(_cardList);
            setRandomWordToTranslate(_cardList);
        }

        //print a random ger word of a list of cards to the lblWordToTranslate control and set its card to the _currentCard
        private void setRandomWordToTranslate(List<Card> listOfCards)
        {
            Random chooseRandomWord = new Random();
            int randomWordIndex = Convert.ToInt32(chooseRandomWord.NextInt64(0, listOfCards.Count));
            _currendCard = listOfCards[randomWordIndex];
            _lblWordToTranslate.Text = _currendCard.GermanWord;
            
        }
        
        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void fillTranslationList(List<Card> listOfCards)
        {
            _lbTranslationList.Items.Clear();
            //printing data to interce
            foreach (Card card in listOfCards)
            {
                _lbTranslationList.Items.Add(card.EnglishWord);
            }

            
        }

        private void btnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            setRandomWordToTranslate(_cardList);
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(_btnSubmit.Text == "Bestätigen")
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
                setRandomWordToTranslate(_cardList);
            }
            
            
        }

        private void _lblValidation_Click(object sender, EventArgs e)
        {

        }

        
        private void WriteCardsToFile()
        {
            //Writing all GermanWord and EnglishWord of all Cards into data.txt
            System.IO.File.WriteAllText(@"D:\Projects\DigitalFlashcard\Flashcard\Flashcard\data.txt", "");
            string[] fileOutputData = new string[_lbTranslationList.Items.Count];
            for (int i = 0; i < fileOutputData.Length; i++)
            {
                Card selectedCard = _cardList.ElementAt(i);
                fileOutputData[i] = selectedCard.GermanWord + "," + selectedCard.EnglishWord;
                
            }
            System.IO.File.WriteAllLines(@"D:\Projects\DigitalFlashcard\Flashcard\Flashcard\data.txt", fileOutputData);
        }
        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            WriteCardsToFile();            
        }
    }
}