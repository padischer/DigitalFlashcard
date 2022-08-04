namespace Flashcard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Card firstCard = new Card();
            firstCard.GermanCard = "Hallo";
            firstCard.EnglishCard = "hello";
            Card secondCard = new Card();
            secondCard.GermanCard = "Tag";
            secondCard.EnglishCard = "day";
            Card thirdCard = new Card();
            thirdCard.GermanCard = "Sprache";
            thirdCard.EnglishCard = "language";

            List<Card> cardList = new List<Card>();
            cardList.Add(firstCard);
            cardList.Add(secondCard);
            cardList.Add(thirdCard);

            foreach(Card card in cardList)
            {
                lbTranslationList.Items.Add(card.EnglishCard);
            }

            Random chooseRandomWord = new Random();
            lblWordToTranslate.Text = cardList[Convert.ToInt32(chooseRandomWord.NextInt64(0, cardList.Count - 1))].GermanCard;
            
        }
    }
}