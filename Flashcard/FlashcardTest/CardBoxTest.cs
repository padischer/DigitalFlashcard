

using Flashcard;
using System;

namespace FlashcardTest
{
    [TestClass]
    public class CarBoxTest
    {
        private bool CompareCards(Card card1, Card card2)
        {
            if (card1 != null && card2 != null)
            {
                if (card1.WordToTranslate == card2.WordToTranslate && card1.Translation == card2.Translation && card1.Difficulty == card2.Difficulty && card1.PrimaryLanguage == card2.PrimaryLanguage && card1.ID == card2.ID && card1.Slot == card2.Slot)
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

        private Card CreateCard(string wordToTranslate, string translation, CardBox.Difficulties difficulty, string key = "")
        {
            return new Card(wordToTranslate, translation, CardBox.Slots.FirstSlot, difficulty, key);
        }

        private CardBox InitCardBox(CardBox.Slots slot = CardBox.Slots.FirstSlot, CardBox.Languages primaryLanguage = CardBox.Languages.German, CardBox.Difficulties difficulty = CardBox.Difficulties.Basic)
        {     
            List<Card> sampleCardList = new List<Card>();
            sampleCardList.Add(CreateCard("Tisch", "table", CardBox.Difficulties.Basic, "rBjSo7Cp3C3TtISnYc"));
            sampleCardList.Add(CreateCard("Sonne", "sun", CardBox.Difficulties.Basic, "dkjUDlm6oa658k3mnC"));
            sampleCardList.Add(CreateCard("Stuhl", "chair", CardBox.Difficulties.Basic, "r0uj2RIS2NUQpgGXO4"));
            sampleCardList.Add(CreateCard("Schrecken", "dread", CardBox.Difficulties.Advanced, "1Uxk723tr0FzNucsO1"));
            sampleCardList.Add(CreateCard("Zorn", "wrath", CardBox.Difficulties.Advanced, "F6L8JgL70qpLFu8WlR"));
            sampleCardList.Add(CreateCard("zögern", "hesitate", CardBox.Difficulties.Advanced, "K0B9I6wEASbQX6bcOx"));
            return new CardBox(slot, primaryLanguage, difficulty, sampleCardList);

        }

        [TestMethod]
        public void TestSwitchDifficutly()
        {
            var sampleBox = InitCardBox();

            sampleBox.SwitchDifficulty();

            Assert.AreEqual(CardBox.Difficulties.Advanced, sampleBox.GetCurrentDifficulty(), "SwitchDifficulty failed");
        }

        [TestMethod]
        public void TestSwitchSlot()
        {
            var sampleBox = InitCardBox();

            sampleBox.SwitchSlot(CardBox.Slots.ThirdSlot);

            Assert.AreEqual(2, (int)sampleBox.GetCurrentSlot(), "SwitchSlot failed");
        }

        [TestMethod]
        public void TestVerifyTranslationWithWrongInput()
        {
            var sampleBox = InitCardBox();
            sampleBox.SetCurrentCard(sampleBox.GetCardList().First());

            bool actual = sampleBox.VerifyTranslation("table");

            Assert.IsTrue(actual, "Verification failed");
            
        }

        [TestMethod]
        public void TestVerifyTranslationWithCorrectInput()
        {
            var sampleBox = InitCardBox();
            sampleBox.SetCurrentCard(sampleBox.GetCardList().First());

            bool actual = sampleBox.VerifyTranslation("Tisch");

            Assert.IsFalse(actual, "wrongly succeeded");
        }

        [TestMethod]
        public void TestResetAllCardSlots()
        {
            var sampleBox = InitCardBox();
            foreach(Card card in sampleBox.GetCardList())
            {
                card.Slot = CardBox.Slots.SecondSlot;
            }

            sampleBox.ResetAllCardSlots();

            int actual = sampleBox.GetCardList().Where(c => c.Slot == CardBox.Slots.FirstSlot).Count();
            Assert.AreEqual(6, actual, "not all Slots where reseted");
        }

        [TestMethod]
        public void TestAddNewCard()
        {
            var sampleBox = InitCardBox();

            sampleBox.AddNewCard("deutsch", "german", "erweitert");

            Assert.IsTrue(CompareCards(CreateCard("deutsch", "german", CardBox.Difficulties.Advanced), sampleBox.GetCardList().Last()), "Card added wrongly");
        }

        [TestMethod]
        public void TestSwitchLanguage()
        {
            var sampleBox = InitCardBox();
            sampleBox.GetCardList().Add(new Card("Test", "Test", CardBox.Slots.FirstSlot, CardBox.Difficulties.Basic));

            sampleBox.SwitchLanguage();

            Assert.AreEqual(sampleBox.GetCardList().Count, sampleBox.GetCardList().Where(c => c.PrimaryLanguage == CardBox.Languages.English).Count(), "Cards Primary Language not switched correctly");
            Assert.AreEqual(CardBox.Languages.English, sampleBox.GetCurrentPrimaryLanguage(), "CardBox Difficulty not switched correctly");
        }

        [TestMethod]
        public void TestGetSaveState()
        {
            var sampleBox = InitCardBox();
            sampleBox.SwitchSlot(CardBox.Slots.ThirdSlot);
            sampleBox.SwitchDifficulty();
            sampleBox.SwitchLanguage();
            Tuple<CardBox.Slots, CardBox.Languages, CardBox.Difficulties> expectedTuple = Tuple.Create(CardBox.Slots.ThirdSlot, CardBox.Languages.English, CardBox.Difficulties.Advanced);

            Tuple<CardBox.Slots, CardBox.Languages, CardBox.Difficulties> actualTuple = sampleBox.GetSaveState();
            Assert.AreEqual(expectedTuple, actualTuple, "wrong saveState output");
        }

        [TestMethod]
        public void TestSelectRandomCard()
        {
            var sampleBox = InitCardBox();

            Card randomCard = sampleBox.SelectRandomCard();

            Assert.AreEqual(true, sampleBox.GetCardList().Contains(randomCard), "card is not in cardlist");
        }

        [TestMethod]
        public void TestGetPossibleTranslations()
        {
            var sampleBox = InitCardBox();
            int actualCount = 0;

            string[] possibleTranslations = sampleBox.GetPossibleTranslations();

            

            /*
            foreach(Card card in sampleBox.GetCardList())
            {
                if (possibleTranslations.Contains(card.Translation))
                {
                    actualCount++;
                }
            }
            */
            Assert.AreEqual(3, sampleBox.GetCardList().Where(c => possibleTranslations.Contains(c.Translation)).Count(), "did not get possible translations correctly");
        }
        
        [TestMethod]
        public void TestGetCurrentDifficultyTextBase()
        {
            var sampleBox = InitCardBox();

            string actual = sampleBox.GetCurrentDifficultyText();

            Assert.AreEqual("basis", actual, "GetCurrentDifficultyText sent wrong text");
        }

        [TestMethod]
        public void TestGetCurrentDifficultyTextAdvanced()
        {
            var sampleBox = InitCardBox(CardBox.Slots.FirstSlot, CardBox.Languages.German, CardBox.Difficulties.Advanced);

            string actual = sampleBox.GetCurrentDifficultyText();

            Assert.AreEqual("erweitert", actual, "GetCurrentDifficultyText sent wrong text");
        }

        [TestMethod]
        public void TestGetCurrentPrimaryLanguageTextGerman()
        {
            var sampleBox = InitCardBox();

            string actual = sampleBox.GetCurrentPrimaryLanguageText();

            Assert.AreEqual("deu->eng", actual, "GetCurrentPrimaryLanguageText sent wrong text");
        }

        [TestMethod]
        public void TestGetCurrentPrimaryLanguageTextEnglish()
        {
            var sampleBox = InitCardBox(CardBox.Slots.FirstSlot, CardBox.Languages.English, CardBox.Difficulties.Basic);

            string actual = sampleBox.GetCurrentPrimaryLanguageText();

            Assert.AreEqual("eng->deu", actual, "GetCurrentPrimaryLanguageText sent wrong text");
        }
    }   
}
