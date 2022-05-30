import { DefaultButton, PrimaryButton } from "@fluentui/react";
import { useIntl } from "react-intl";

const ButtonsNotLogged = () => {
    const intl = useIntl();

    return (
        <div className="sb-user-info">
            <DefaultButton
                className="sb-header-login"
                text={intl.formatMessage({ id: "app.login.button" })}
                onClick={() =>
                    window.location.href = '/login'
                }
            />
            <PrimaryButton
                className="sb-header-register"
                text={intl.formatMessage({ id: "app.register.btn" })}
                onClick={() =>
                    window.location.href = '/register'
                }
            />
        </div>
    )
};

export default ButtonsNotLogged;