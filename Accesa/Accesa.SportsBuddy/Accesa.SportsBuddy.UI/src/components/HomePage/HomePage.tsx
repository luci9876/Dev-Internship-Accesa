import UserMainPage from './components/UserMainPage';
import LandingPage from './components/LandingPage';

const HomePage = () => {
    const accountExists = localStorage.getItem('accountExists');

    return (
        accountExists === "true"
            ? <UserMainPage />
            : <LandingPage />
    )
};

export default HomePage;