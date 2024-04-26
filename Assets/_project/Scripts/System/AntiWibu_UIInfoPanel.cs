using TMPro;

public class AntiWibu_UIInfoPanel : AntiWibu_UIPanel
{
    public TMP_Text descriptionText;
    public void ChangeDescription(string text)
    {
        this.descriptionText.text = text;
    }
}
