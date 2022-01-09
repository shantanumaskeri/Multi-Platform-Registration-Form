using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Registration : MonoBehaviour
{

    public InputField nameField;
	public InputField organizationField;
	public InputField emailField;
    public InputField telephoneField;
    public Image profilePicField;
    public Text nameMessage;
    public Text organizationMessage;
    public Text emailMessage;
    public Text telephoneMessage;
    public Text fileUploadMessage;
    public Text successMessage;
    
    private string userName;
	private string userOrganization;
	private string userEmail;
    private string userTelephone;
    
	private bool isNameCorrect;
	private bool isOrganizationCorrect;
	private bool isEmailCorrect;
    private bool isTelephoneCorrect;
    [HideInInspector]
    public bool isImageUploadCorrect;

    public static Registration Instance;

    private void Start()
    {
        Instance = this;

    	isNameCorrect = isOrganizationCorrect = isEmailCorrect = isTelephoneCorrect = isImageUploadCorrect = false;
    }

	public void CheckRegistration()
    {
    	userName = nameField.text;
    	userOrganization = organizationField.text;
        userEmail = emailField.text.ToLower();
        userTelephone = telephoneField.text;

        if (IsValidName(userName))
        {
        	isNameCorrect = true;
            nameMessage.text = "";
        }
        else
        {
        	isNameCorrect = false;
            nameMessage.text = "Please enter a valid name.";

            StartCoroutine(ClearErrorMessage(nameMessage));
        }

        if (IsValidOrganization(userOrganization))
        {
        	isOrganizationCorrect = true;
            organizationMessage.text = "";
        }
        else
        {
        	isOrganizationCorrect = false;
            organizationMessage.text = "Please enter a valid organization.";

            StartCoroutine(ClearErrorMessage(organizationMessage));
        }

        if (IsValidEmailAddress(userEmail))
        {
        	isEmailCorrect = true;
            emailMessage.text = "";
        }
        else
        {
            isEmailCorrect = false;
            emailMessage.text = "Please enter a valid email.";

            StartCoroutine(ClearErrorMessage(emailMessage));
        }

        if (IsValidTelephoneNumber(userTelephone))
        {
            isTelephoneCorrect = true;
            telephoneMessage.text = "";
        }
        else
        {
            isTelephoneCorrect = false;
            telephoneMessage.text = "Please enter a valid telephone number.";

            StartCoroutine(ClearErrorMessage(telephoneMessage));
        }

        if (!isImageUploadCorrect)
		{
            fileUploadMessage.text = "Please upload a profile pic.";

            StartCoroutine(ClearErrorMessage(fileUploadMessage));
        }

        if (isNameCorrect && isOrganizationCorrect && isEmailCorrect && isTelephoneCorrect && isImageUploadCorrect)
        {
            successMessage.text = "Form Subitted Successfully!";

            nameField.text = organizationField.text = emailField.text = telephoneField.text = "";
            nameMessage.text = organizationMessage.text = emailMessage.text = telephoneMessage.text = fileUploadMessage.text = "";

            profilePicField.sprite = null;

            StartCoroutine(ClearErrorMessage(successMessage));
        }
	}

    private IEnumerator ClearErrorMessage(Text message)
    {
        yield return new WaitForSeconds(2.0f);

        message.text = "";
    }

    private bool IsValidName(string name)
    {
        if (name.Length < 2)
            return false;

        if (name.IndexOf("@") >= 0 || name.IndexOf(".") >= 0 || name.IndexOf("!") >= 0 || name.IndexOf("#") >= 0 || name.IndexOf("$") >= 0 || name.IndexOf("%") >= 0 || name.IndexOf("^") >= 0 || name.IndexOf("&") >= 0 || name.IndexOf("*") >= 0 || name.IndexOf("(") >= 0 || name.IndexOf(")") >= 0 || name.IndexOf("-") >= 0 || name.IndexOf("=") >= 0 || name.IndexOf("+") >= 0 || name.IndexOf("[") >= 0 || name.IndexOf("{") >= 0 || name.IndexOf("]") >= 0 || name.IndexOf("}") >= 0 || name.IndexOf(":") >= 0 || name.IndexOf(";") >= 0 || name.IndexOf("'") >= 0 || name.IndexOf("|") >= 0 || name.IndexOf(",") >= 0 || name.IndexOf("<") >= 0 || name.IndexOf(">") >= 0 || name.IndexOf("/") >= 0 || name.IndexOf("?") >= 0 || name.IndexOf("_") >= 0)
            return false;

        if (name.IndexOf("0") >= 0 || name.IndexOf("1") >= 0 || name.IndexOf("2") >= 0 || name.IndexOf("3") >= 0 || name.IndexOf("4") >= 0 || name.IndexOf("5") >= 0 || name.IndexOf("6") >= 0 || name.IndexOf("7") >= 0 || name.IndexOf("8") >= 0 || name.IndexOf("9") >= 0)
            return false;

        return true;
    }

    private bool IsValidOrganization(string organization)
    {
        if (organization.Length < 2)
            return false;

        if (organization.IndexOf("@") >= 0 || organization.IndexOf(".") >= 0 || organization.IndexOf("!") >= 0 || organization.IndexOf("#") >= 0 || organization.IndexOf("$") >= 0 || organization.IndexOf("%") >= 0 || organization.IndexOf("^") >= 0 || organization.IndexOf("&") >= 0 || organization.IndexOf("*") >= 0 || organization.IndexOf("(") >= 0 || organization.IndexOf(")") >= 0 || organization.IndexOf("-") >= 0 || organization.IndexOf("=") >= 0 || organization.IndexOf("+") >= 0 || organization.IndexOf("[") >= 0 || organization.IndexOf("{") >= 0 || organization.IndexOf("]") >= 0 || organization.IndexOf("}") >= 0 || organization.IndexOf(":") >= 0 || organization.IndexOf(";") >= 0 || organization.IndexOf("'") >= 0 || organization.IndexOf("|") >= 0 || organization.IndexOf(",") >= 0 || organization.IndexOf("<") >= 0 || organization.IndexOf(">") >= 0 || organization.IndexOf("/") >= 0 || organization.IndexOf("?") >= 0)
            return false;

        return true;
    }

    private bool IsValidEmailAddress(string email)
    {
        #region general conditions

        if (email.IndexOf("@") == -1)
            return false;


        if (email.IndexOf("!") >= 0 || email.IndexOf("#") >= 0 || email.IndexOf("$") >= 0 || email.IndexOf("%") >= 0 || email.IndexOf("^") >= 0 || email.IndexOf("&") >= 0 || email.IndexOf("*") >= 0 || email.IndexOf("(") >= 0 || email.IndexOf(")") >= 0 || email.IndexOf("=") >= 0 || email.IndexOf("+") >= 0 || email.IndexOf("[") >= 0 || email.IndexOf("{") >= 0 || email.IndexOf("]") >= 0 || email.IndexOf("}") >= 0 || email.IndexOf(":") >= 0 || email.IndexOf(";") >= 0 || email.IndexOf("'") >= 0 || email.IndexOf("|") >= 0 || email.IndexOf(",") >= 0 || email.IndexOf("<") >= 0 || email.IndexOf(">") >= 0 || email.IndexOf("/") >= 0 || email.IndexOf("?") >= 0)
            return false;


        if (email.IndexOf("0") == 0 || email.IndexOf("1") == 0 || email.IndexOf("2") == 0 || email.IndexOf("3") == 0 || email.IndexOf("4") == 0 || email.IndexOf("5") == 0 || email.IndexOf("6") == 0 || email.IndexOf("7") == 0 || email.IndexOf("8") == 0 || email.IndexOf("9") == 0 || email.IndexOf("@") == 0 || email.IndexOf("-") == 0 || email.IndexOf("_") == 0 || email.IndexOf(".") == 0)
            return false;


        if (email.IndexOf("@") != email.LastIndexOf("@"))
            return false;

        #endregion
        
        if (email != "")
        {
            #region divide email into two parts - name & domain

            string[] email_division = email.Split("@"[0]);
            string email_name = email_division[0];
            string email_domain = "@" + email_division[1];
            
            #endregion

            #region email name conditions

            if (email_name.IndexOf(".") != -1)
            {
                if (email_name.IndexOf(".") == 0)
                    return false;

                if (email_name.IndexOf(".") != email_name.LastIndexOf("."))
                    return false;

                if (email_name.IndexOf(".") == (email_name.Length - 1))
                    return false;
            }

            if (email_name.IndexOf("-") != -1)
			{
                if (email_name.IndexOf("-") != email_name.LastIndexOf("-"))
                    return false;

                if (Mathf.Abs(email_name.IndexOf("-") - email_name.IndexOf(".")) == 1)
                    return false;
            }

            if (email_name.IndexOf("_") != -1)
            {
                if (email_name.IndexOf("_") != email_name.LastIndexOf("_"))
                    return false;

                if (Mathf.Abs(email_name.IndexOf("_") - email_name.IndexOf(".")) == 1)
                    return false;

                if (Mathf.Abs(email_name.IndexOf("_") - email_name.IndexOf("@")) == 1)
                    return false;
            }

            #endregion

            #region email domain conditions

            if (email_domain.IndexOf(".") == -1)
                return false;

            if (email_domain.IndexOf(".") != email_domain.LastIndexOf("."))
            {
                if ((email_domain.LastIndexOf(".") - email_domain.IndexOf(".")) < 3)
                    return false;
            }
            else
            {
                if ((email_domain.IndexOf(".") - email_domain.IndexOf("@")) < 3)
                    return false;
            }

            if (email_domain.IndexOf("-") != -1)
            {
                if (email_domain.IndexOf("-") != email_domain.LastIndexOf("-"))
                    return false;

                if (Mathf.Abs(email_domain.IndexOf("-") - email_domain.IndexOf(".")) == 1)
                    return false;
            }

            if (email_domain.IndexOf("_") != -1)
                return false;

            #endregion
        }

        return true;
    }

    private bool IsValidTelephoneNumber(string telephone)
    {
        if (telephone.Length < 9 || telephone.Length > 10)
            return false;

        return true;
    }

}
