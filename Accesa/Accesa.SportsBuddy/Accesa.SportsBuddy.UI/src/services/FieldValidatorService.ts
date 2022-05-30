import { rules } from "../helpers/regex";
class FieldValidatorService {

    public validateFieldLength = (value: string) => {
        return value.length ? "" : "Field cannot be empty!"
    }

    public validateEmail = (email: string) => {
        if (!this.validateFieldLength(email).length) {
            return RegExp(rules.EMAIL).test(email) ? "" : "Please insert a valid email address!"
        }
        return this.validateFieldLength(email)
    }

    public validatePhoneNumber = (phoneNumber: string) => {
        if (!this.validateFieldLength(phoneNumber).length) {
            return RegExp(rules.PHONENUMBER).test(phoneNumber) ? "" : "Please insert a valid phone number!"
        }
        return this.validateFieldLength(phoneNumber)
    }
}

export default new FieldValidatorService();