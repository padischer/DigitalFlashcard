namespace Flashcard
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        
        private Slot _slot1 = new Slot();
        private Slot _slot2 = new Slot();
        private Slot _slot3 = new Slot();
        private List<Slot> _slotList = new List<Slot>();
        private string _dataFilePath = System.IO.Path.Combine(System.IO.Directory.GetCurrentDirectory(), "data.txt");
        private CardBox _box;

        //on start of Form adding Slotnumbers to combobox
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetClassVariables();

            //editing comboBox _cbSlotNumber
            _cbSlotNumber.Items.Add(_slot1.SlotID.ToString());
            _cbSlotNumber.Items.Add(_slot2.SlotID.ToString());
            _cbSlotNumber.Items.Add(_slot3.SlotID.ToString());
            _cbSlotNumber.SelectedIndex = 0;
            
            //printing data to interface
            FillTranslationList();
            SetRandomWordToTranslate();
        }

        //setting class variables of slot and CardBox objects
        private void SetClassVariables()
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
            _box = new CardBox(_slotList, _dataFilePath);
        }

        //temp choosing a random word to Translate
        private void BtnSwitchDifficulty_Click(object sender, EventArgs e)
        {
            SetRandomWordToTranslate();
        }

        //clear lbTanslation List and fill it with each eng word of a list of cards 
        private void FillTranslationList()
        {
            _lbTranslationList.Items.Clear();
            string[] listOfTranslations = _box.ShowPossibleTranslations();
            foreach (string word in listOfTranslations)
            {
                _lbTranslationList.Items.Add(word);
            } 
        }

        //checking wether the selected item in _lbTranslationList equals the correct Translation of _lblWordToTranslate
        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            const string buttonText = "Bestätigen";

            if(_btnSubmit.Text == buttonText)
            {
                _btnSubmit.Text = "Weiter";
                _lblValidation.Text = _box.VerifyTranslation(_lbTranslationList.SelectedItem.ToString());
            }
            else
            {
                _btnSubmit.Text = buttonText;
                _lblValidation.Text = "";
                SetRandomWordToTranslate();
            }


            FillTranslationList();
        }

        //choosing a random word to Translate
        private void SetRandomWordToTranslate()
        {
            _lblWordToTranslate.Text = _box.SelectRandomWordToTranslate();

        }

        //if Slotnumber is changed adjust Translationlist and WortToTranslate to the new Slot
        private void CbSlotNumberSelectIndexChanged(object sender, EventArgs e)
        {
            _box.switchSlot(Int32.Parse(_cbSlotNumber.SelectedItem.ToString()));
            FillTranslationList();
            SetRandomWordToTranslate();
        }

        private void BtnSwitchLanguage_Click(object sender, EventArgs e)
        {
            _box.SwitchAllCardLanguage();
            FillTranslationList();
            SetRandomWordToTranslate();
        }
    }
}