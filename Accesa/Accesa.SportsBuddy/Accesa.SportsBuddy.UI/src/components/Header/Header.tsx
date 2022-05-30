import { Breadcrumb, IBreadcrumbItem } from '@fluentui/react';
import './Header.scss';
import ButtonsNotLogged from './components/ButtonsNotLogged';
import ButtonsLoggedIn from './components/ButtonsLoggedIn';
import { useContext } from 'react';
import { SideBarContext } from '../../SideBarContext';
import { LanguageContext } from '../../LanguageContext';
import { useIntl } from 'react-intl';
import ThemeToggle from '../ThemeToggle/ThemeToggle';
import { FcSportsMode } from 'react-icons/fc';
import { GiHamburgerMenu } from 'react-icons/gi';

const items: IBreadcrumbItem[] = [
    {
        text: 'SportsBuddy',
        key: '',
        href: '/'
    },
    {
        text: `${(window.location.pathname
            .substring(1)
            .split("-")
            .map(word => {
                return word.charAt(0).toUpperCase() + word.substring(1);
            })
            .join(" "))}`,
        key: '',
        href: window.location.pathname.substring(1)
    }
];

const Header = () => {

    const isLogged = localStorage.getItem("accountExists") === "true";

    const { sideBar, setSideBar } = useContext(SideBarContext);

    const toggleSideBar = () => setSideBar(!sideBar);

    const intl = useIntl();

    const { langRO, setLangRO } = useContext(LanguageContext);

    return (
        <div className="sb-header-container">
            <div className="sb-logo-container">
                <abbr title={intl.formatMessage({ id: "app.header.menu" })}>
                    <GiHamburgerMenu
                        className="sb-hamburger-menu"
                        onClick={toggleSideBar}
                    />
                </abbr>
                <abbr title={intl.formatMessage({ id: "app.header.logomessage" })}>
                    < FcSportsMode
                        className="sb-logo" />
                </abbr>
            </div>
            <div className="sb-breadcrumb">
                <Breadcrumb
                    items={items}
                    maxDisplayedItems={4}
                    overflowAriaLabel="More links"
                />
            </div>
            <div className="sb-user-container">
                <ThemeToggle />
                {
                    isLogged
                        ? <ButtonsLoggedIn />
                        : <ButtonsNotLogged />
                }
                <div className="sb-language-container">
                    <img
                        className="sb-language" src="/european-union.png" alt="EN"
                        onClick={() => {
                            setLangRO(false);
                            sessionStorage.setItem('language', `${langRO}`)
                        }}
                    />
                    <img
                        className="sb-language" src="/romania.png" alt="RO"
                        onClick={() => {
                            setLangRO(true);
                            sessionStorage.setItem('language', `${langRO}`)
                        }}
                    />
                </div>
            </div >
        </div >
    )
};

export default Header;