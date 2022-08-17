using AirtableApiClient;
namespace Flashcard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private CardBox _box = new CardBox();

        //on start of Form adding Slotnumbers to combobox
        private void MainForm_Load(object sender, EventArgs e)
        {
            _cbSlotNumber.Items.Add("1");
            _cbSlotNumber.Items.Add("2");
            _cbSlotNumber.Items.Add("3");


            LoadSaveState();

            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void LoadSaveState()
        {
            if(_box.GetCurrentDifficulty() == CardBox.Difficulties.Basic)
            {
                _btnSwitchDifficulty.Text = "basis";
            }
            else
            {
                _btnSwitchDifficulty.Text = "erweitert";
            }

            if(_box.GetPrimaryLanguage() == CardBox.Languages.German)
            {
                _btnSwitchLanguage.Text = "deu->eng";
            }
            else
            {
                _btnSwitchLanguage.Text = "eng->deu";
            }

            _cbSlotNumber.SelectedIndex = _box.GetCurrentSlotIndex();
        }

        //temp choosing a random word to Translate
        private void BtnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            _box.SwitchDifficulty();
            FillTranslationList();
            SetRandomWordToTranslate();
            if (_btnSwitchDifficulty.Text == "basis")
            {
                _btnSwitchDifficulty.Text = "erweitert";
            }
            else
            {
                _btnSwitchDifficulty.Text = "basis";
            }
        }

        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void FillTranslationList()
        {
            _lbTranslationList.Items.Clear();
            string[] listOfTranslations = _box.GetPossibleTranslations();
            foreach (string word in listOfTranslations)
            {
                _lbTranslationList.Items.Add(word);
            } 
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (_lbTranslationList.SelectedItems.Count == 1)
            {
                const string buttonText = "Bestätigen";

                if (_btnSubmit.Text == buttonText)
                {
                    _btnSubmit.Text = "Weiter";
                    _lblValidation.Text = _box.VerifyTranslation(_lbTranslationList.SelectedItem.ToString());
                }
                else
                {
                    _btnSubmit.Text = buttonText;
                    _lblValidation.Text = "";
                    SetRandomWordToTranslate();
                    FillTranslationList();
                }
            }
        }

        //choosing a random word to Translate
        private void SetRandomWordToTranslate()
        {
            _lblWordToTranslate.Text = _box.SelectRandomWordToTranslate();
        }

        //if Slotnumber is changed adjust Translationlist and WortToTranslate to the new Slot
        private void CbSlotNumberSelectIndexChanged(object sender, EventArgs e)
        {
            _box.SwitchSlot(Int32.Parse(_cbSlotNumber.SelectedItem.ToString()));
            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void BtnSwitchLanguage_Click(object sender, EventArgs e)
        {
            _box.SwitchLanguage();
            FillTranslationList();
            SetRandomWordToTranslate();
            if(_btnSwitchLanguage.Text == "deu->eng")
            {
                _btnSwitchLanguage.Text = "eng->deu";
            }
            else
            {
                _btnSwitchLanguage.Text = "deu->eng";
            }
        }

        private void BtnAddCard_OnClick(object sender, EventArgs e)
        { 
            
            AddCard addCard = new AddCard(this);
            addCard.ShowDialog();
            if (addCard.ShouldExecute)
            {
                
                _box.AddNewCard(addCard.GetGermanWord(), addCard.GetEnglishWord(), addCard.GetDifficulty());
                _box.PostNewCard(addCard.GetEnglishWord(), addCard.GetEnglishWord(), addCard.GetDifficulty());
                FillTranslationList();
            }
        }

        private void BtnEndProgram_Click(object sender, EventArgs e)
        {
            _box.UpdateSaveState();
            this.Close();
           
        }

        private void BtnReset(object sender, EventArgs e)
        {
            _box.ResetAllCardSlots();
            FillTranslationList();
        }
    }
}