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

            for (int i = 0; i < fileInputData.Length / 2; i=i+2)
            {
                _cardList.Add(new Card(fileInputData[i], fileInputData[i + 1]));
            }


            //generating example data
            /*
            Card firstCard = new Card("Hallo", "hello");
            Card secondCard = new Card("Tag", "day");
            Card thirdCard = new Card("Tisch", "Table");
            */
            _cardList.Add(firstCard);
            _cardList.Add(secondCard);
            _cardList.Add(thirdCard);

            //printing data to interce
            fillTranslationList(_cardList);
            setRandomWordToTranslate(_cardList);
        }

        //print a random ger word of a list of cards to the lblWordToTranslate control and set its card to the _currentCard
        private void setRandomWordToTranslate(List<Card> listOfCards)
        {
            Random chooseRandomWord = new Random();
            int randomWordIndex = Convert.ToInt32(chooseRandomWord.NextInt64(0, listOfCards.Count));
            _currendCard = listOfCards[randomWordIndex];
            _lblWordToTranslate.Text = _currendCard._GermanWord;
            
        }
        
        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void fillTranslationList(List<Card> listOfCards)
        {
            _lbTranslationList.Items.Clear();
            //printing data to interce
            foreach (Card card in listOfCards)
            {
                _lbTranslationList.Items.Add(card._EnglishWord);
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
                if (_lbTranslationList.SelectedItem.ToString() == _currendCard._EnglishWord)
                {
                    _lblValidation.Text = "Korrekt";
                }
                else
                {
                    _lblValidation.Text = "Falsch! " + _currendCard._EnglishWord + " wäre richtig gewesen";
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

        

        private void MainForm_Closing(object sender, FormClosingEventArgs e)
        {
            //Writing all GermanWord and EnglishWord of all Cards into data.txt
            System.IO.File.WriteAllText(@"D:\Projects\DigitalFlashcard\Flashcard\Flashcard\data.txt", "");
            string[] fileOutputData = new string[_lbTranslationList.Items.Count*2];
            for (int i = 0; i < fileOutputData.Length; i = i + 2)
            {
                fileOutputData[i] = _cardList.ElementAt(i / 2)._GermanWord;
                fileOutputData[i + 1] = _cardList.ElementAt(i / 2)._EnglishWord;
            }
            System.IO.File.WriteAllLines(@"D:\Projects\DigitalFlashcard\Flashcard\Flashcard\data.txt", fileOutputData);

        }
    }
}