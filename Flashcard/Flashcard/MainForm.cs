namespace Flashcard
{
    public partial class mainForm : Form
    {

        private List<Card> _cardList = new List<Card>();
        private Card _currendCard;
        public mainForm()
        {
            InitializeComponent();

            
        }

        //print a random ger word of a list of cards to the lblWordToTranslate control and set its card to the _currentCard
        private void setRandomWordToTranslate(List<Card> listOfCards)
        {
            Random chooseRandomWord = new Random();
            int randomWordIndex = Convert.ToInt32(chooseRandomWord.NextInt64(0, listOfCards.Count));
            lblWordToTranslate.Text = listOfCards[randomWordIndex].GermanCard;   
        }
        
        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void fillTranslationList(List<Card> listOfCards)
        {
            lbTranslationList.Items.Clear();
            //printing data to interce
            foreach (Card card in listOfCards)
            {
                lbTranslationList.Items.Add(card.EnglishCard);
            }

            
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
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
            /*
             * Test
             */
            
            
        }
    }
}