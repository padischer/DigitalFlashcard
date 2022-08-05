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

        //print a random ger word of a list of cards to the lblWordToTranslate control and set its card to the _currentCard
        private void setRandomWordToTranslate(List<Card> listOfCards)
        {
            Random chooseRandomWord = new Random();
            int randomWordIndex = Convert.ToInt32(chooseRandomWord.NextInt64(0, listOfCards.Count));
            _currendCard = listOfCards[randomWordIndex];
            _lblWordToTranslate.Text = _currendCard.GermanCard;
            
        }
        
        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void fillTranslationList(List<Card> listOfCards)
        {
            _lbTranslationList.Items.Clear();
            //printing data to interce
            foreach (Card card in listOfCards)
            {
                _lbTranslationList.Items.Add(card.EnglishCard);
            }

            
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {

            string[] fileData = System.IO.File.ReadAllLines("data.txt");

            for (int i = 0; i < fileData.Length / 3; i++)
            {
                
            }


            //generating example data
            Card firstCard = new Card();
            firstCard.GermanCard = "Hallo";
            firstCard.EnglishCard = "hello";
            Card secondCard = new Card();
            secondCard.GermanCard = "Tag";
            secondCard.EnglishCard = "day";
            Card thirdCard = new Card();
            thirdCard.GermanCard = "Tisch";
            thirdCard.EnglishCard = "table";

            _cardList.Add(firstCard);
            _cardList.Add(secondCard);
            _cardList.Add(thirdCard);

            //printing data to interce
            fillTranslationList(_cardList);
            setRandomWordToTranslate(_cardList);

            
        }

        private void btnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            setRandomWordToTranslate(_cardList);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(_btnSubmit.Text == "Bestätigen")
            {
                if (_lbTranslationList.SelectedItem.ToString() == _currendCard.EnglishCard)
                {
                    _lblValidation.Text = "Korrekt";
                }
                else
                {
                    _lblValidation.Text = "Falsch! " + _currendCard.EnglishCard + " wäre richtig gewesen";
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
    }
}