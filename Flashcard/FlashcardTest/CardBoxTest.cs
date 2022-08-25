

namespace FlashcardTest
{
    [TestClass]
    public class CarBoxTest
    {
        public bool CompareCards(Flashcard.Card card1, Flashcard.Card card2)
        {
            if (card1 != null && card2 != null)
            {
                if (card1.WordToTranslate == card2.WordToTranslate && card1.Translation == card2.Translation && card1.Difficulty == card2.Difficulty && card1.PrimaryLanguage == card2.PrimaryLanguage && card1.ID == card2.ID && card1.SlotID == card2.SlotID)
                {
                    return true;
                }
            }
            else if (card1 == null && card2 != null)
            {
                return false;
            }
            return false;

        }

        private Flashcard.Card CreateCard(string wordToTranslate, string translation, Flashcard.CardBox.Difficulties difficulty, List<Flashcard.Card> cardList, string key = "")
        {
            return new Flashcard.Card(wordToTranslate, translation, 1, difficulty, key);
        }

        private Flashcard.CardBox InitCardBox(int[] saveState=null)
        {     
            List<Flashcard.Card> sampleCardList = new List<Flashcard.Card>();
            sampleCardList.Add(CreateCard("Tisch", "table", Flashcard.CardBox.Difficulties.Basic, sampleCardList, "rBjSo7Cp3C3TtISnYc"));
            sampleCardList.Add(CreateCard("Sonne", "sun", Flashcard.CardBox.Difficulties.Basic, sampleCardList, "dkjUDlm6oa658k3mnC"));
            sampleCardList.Add(CreateCard("Stuhl", "chair", Flashcard.CardBox.Difficulties.Basic, sampleCardList, "r0uj2RIS2NUQpgGXO4"));
            sampleCardList.Add(CreateCard("Schrecken", "dread", Flashcard.CardBox.Difficulties.Advanced, sampleCardList, "1Uxk723tr0FzNucsO1"));
            sampleCardList.Add(CreateCard("Zorn", "wrath", Flashcard.CardBox.Difficulties.Advanced, sampleCardList, "F6L8JgL70qpLFu8WlR"));
            sampleCardList.Add(CreateCard("zögern", "hesitate", Flashcard.CardBox.Difficulties.Advanced, sampleCardList, "K0B9I6wEASbQX6bcOx"));
            if (saveState == null)
            {
                return new Flashcard.CardBox(new int[] { 0, 0, 0 }, sampleCardList);
            }
            return new Flashcard.CardBox(saveState, sampleCardList);
        }

        [TestMethod]
        public void TestSwitchDifficutly()
        {
            var sampleBox = InitCardBox();

            sampleBox.SwitchDifficulty();

            Assert.AreEqual(Flashcard.CardBox.Difficulties.Advanced, sampleBox.GetCurrentDifficulty(), "SwitchDifficulty failed");
        }

        [TestMethod]
        public void TestSwitchSlot()
        {
            var sampleBox = InitCardBox();
            int expected = 0;

            sampleBox.SwitchSlot(0);

            int actual = sampleBox.GetCurrentSlotIndex();
            Assert.AreEqual(expected, actual, "too small input uncatched");
        }

        [TestMethod]
        public void TestSwitchSlot1()
        {
            var sampleBox = InitCardBox();
            int expected = 2;

            sampleBox.SwitchSlot(3);

            int actual = sampleBox.GetCurrentSlotIndex();
            Assert.AreEqual(expected, actual, "SwitchSlot failed");
        }

        [TestMethod]
        public void TestVerifyTranslation()
        {
            var sampleBox = InitCardBox();
            sampleBox.SetCurrentCard(sampleBox.GetCardList().First());
            bool expected = true;

            bool actual = sampleBox.VerifyTranslation("table");

            Assert.AreEqual(expected, actual, "Verification failed");
        }

        [TestMethod]
        public void TestVerifyTranslation1()
        {
            var sampleBox = InitCardBox();
            sampleBox.SetCurrentCard(sampleBox.GetCardList().First());
            bool expected = false;

            bool actual = sampleBox.VerifyTranslation("Tisch");

            Assert.AreEqual(expected, actual, "wrongly succeeded");
        }

        [TestMethod]
        public void TestResetAllCardSlots()
        {
            var sampleBox = InitCardBox();
            foreach(Flashcard.Card card in sampleBox.GetCardList())
            {
                card.SlotID = 2;
            }
            int expected = 6;

            sampleBox.ResetAllCardSlots();

            int actual = sampleBox._cardList.Where(c => c.SlotID == 1).Count();
            Assert.AreEqual(expected, actual, "not all Slots where reseted");
        }

        [TestMethod]
        public void TestAddNewCard()
        {
            var sampleBox = InitCardBox();

            sampleBox.AddNewCard("deutsch", "german", "erweitert");

            List<Flashcard.Card> tempList = new List<Flashcard.Card>();

            
            Assert.AreEqual(true ,CompareCards(CreateCard("deutsch", "german", Flashcard.CardBox.Difficulties.Advanced, tempList), sampleBox.GetCardList().Last()), "Card added wrongly");
        }

        [TestMethod]
        public void TestSwitchLanguage()
        {
            var sampleBox = InitCardBox();
            sampleBox._cardList.Add(new Flashcard.Card("Test", "Test", 1, Flashcard.CardBox.Difficulties.Basic));
            int expected = sampleBox.GetCardList().Count;
            sampleBox.SwitchLanguage();

            Assert.AreEqual(expected, sampleBox.GetCardList().Where(c => c.PrimaryLanguage == Flashcard.CardBox.Languages.English).Count(), "Cards Primary Language not switched correctly");
            Assert.AreEqual(Flashcard.CardBox.Languages.English, sampleBox.GetCurrentPrimaryLanguage(), "CardBox Difficulty not switched correctly");
        }

        [TestMethod]
        public void TestGetSaveState()
        {
            var sampleBox = InitCardBox();
            sampleBox.SwitchSlot(3);
            sampleBox.SwitchDifficulty();
            sampleBox.SwitchLanguage();
            int[] expectedArray = { 2, 1, 1 };
            
            
            Assert.AreEqual(true, CompareArray(expectedArray, sampleBox.GetSaveState()), "wrong saveState output");
        }

        private bool CompareArray(int[] arr1, int[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
               for(int i = 0; i < arr1.Length; i++)
               {
                    if (arr1[i] == arr2[i])
                    {
                        
                    }
                    else
                    {
                        return false;
                    }      
               }
                return true;
            }
            else
            {
                return false;
            }
        }

        [TestMethod]
        public void TestSelectRandomCard()
        {
            var sampleBox = InitCardBox();
            Flashcard.Card randomCard = sampleBox.SelectRandomCard();
            bool actual;
            if (sampleBox.GetCardList().Contains(randomCard)){
                actual = true;
            }
            else
            {
                actual = false;
            }
            Assert.AreEqual(true, actual, "card is not in cardlist");
        }

        [TestMethod]
        public void TestGetPossibleTranslations()
        {
            var sampleBox = InitCardBox();
            int actualCount = 0;
            string[] possibleTranslations = sampleBox.GetPossibleTranslations();

            foreach(Flashcard.Card card in sampleBox.GetCardList())
            {
                if (possibleTranslations.Contains(card.Translation))
                {
                    actualCount++;
                }
            }
            Assert.AreEqual(3, actualCount, "did not get possible translations correctly");
        }
        
        [TestMethod]
        public void TestGetCurrentDifficulty()
        {
            var sampleBox = InitCardBox();
            Assert.AreEqual("basis", sampleBox.GetCurrentDifficultyText(), "GetCurrentDifficultyText sent wrong text");
        }

        [TestMethod]
        public void TestGetCurrentDifficulty1()
        {
            var sampleBox = InitCardBox(new int[] {0,0,1});
            Assert.AreEqual("erweitert", sampleBox.GetCurrentDifficultyText(), "GetCurrentDifficultyText sent wrong text");
        }

        [TestMethod]
        public void TestGetCurrentPrimaryLanguage()
        {
            var sampleBox = InitCardBox();
            Assert.AreEqual("deu->eng", sampleBox.GetCurrentPrimaryLanguageText(), "GetCurrentPrimaryLanguageText sent wrong text");
        }

        [TestMethod]
        public void TestGetCurrentPrimaryLanguage1()
        {
            var sampleBox = InitCardBox(new int[] {0,1,0});
            Assert.AreEqual("eng->deu", sampleBox.GetCurrentPrimaryLanguageText(), "GetCurrentPrimaryLanguageText sent wrong text");
        }
        /*
        [TestMethod]
        public void Test()
        {
            var sampleBox = InitCardBox();
        }
        */

    }
}
