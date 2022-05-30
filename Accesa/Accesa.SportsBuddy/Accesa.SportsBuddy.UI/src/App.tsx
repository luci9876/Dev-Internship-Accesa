import './App.scss';
import {
  BrowserRouter as Router,
  Switch,
  Route
} from "react-router-dom";
import RegisterUser from './components/RegisterUser/RegisterUser';
import TrainerDashboard from './components/TrainerDashboard/TrainerDashboard';
import ActivityPage from './components/TrainingPrograms/ActivityPage';
import LoginUser from './components/LoginUser/LoginUser';
import HomePage from './components/HomePage/HomePage';
import RegisterAdmin from './components/RegisterAdmin/RegisterAdmin';
import LoginAdmin from './components/LoginAdmin/LoginAdmin';
import NavigationBar from './components/NavigationBar/NavigationBar';
import Header from './components/Header/Header';
import Footer from './components/Footer/Footer';
import UserProfile from './components/UserProfile/UserProfile';
import ChallengesPage from './components/ChallengesPage/ChallengesPage';
import MyChallanges from './components/MyChallenges/MyChallanges';
import CreateChallenge from './components/CreateChallenge/CreateChallenge';
import EditChallenge from './components/EditChallange/EditChallenge';
import { SideBarContext } from './SideBarContext';
import { LanguageContext } from './LanguageContext';
import { useState } from 'react';
import Activity from './components/TrainingPrograms/Activity';
import SportsCenterProfile from './components/SportsCenter/SportsCenterProfile';
import SportsCenterList from './components/SportsCenter/SportsCenterList';
import EditTrainerEvent from './components/EditEvent/EditTrainerEvent';
import UserLeaderboard from './components/UserLeaderboard/UserLeaderboard';
import EventsPage from './components/EventsPage/EventsPage';
import CreateEventPage from './components/CreateEvent/CreateEventPage';
import MyEventsPage from './components/MyEvents/MyEventsPage';
import { IntlProvider } from "react-intl";
import English from "./languages/en-US.json";
import Romanian from "./languages/ro-RO.json";

const App = () => {

  const [langRO, setLangRO] = useState(sessionStorage.getItem('language') === "false");

  let lang = English;

  if (langRO) {
    lang = Romanian;
  }

  const browserLocale: string = navigator.language;

  if (browserLocale === "ro-RO") {
    lang = Romanian;
  }

  const [sideBar, setSideBar] = useState(false);
  return (
    <div className="App">
      <IntlProvider locale={browserLocale} messages={lang}>
        <LanguageContext.Provider value={{ langRO, setLangRO }}>
          <SideBarContext.Provider value={{ sideBar, setSideBar }}>
            <Header />
            <div className="Content">
              <NavigationBar />
              <div className="sb-router">
                <Router>
                  <Switch>
                    <Route path="/my-events">
                      <MyEventsPage />
                    </Route>
                    <Route path="/events">
                      <EventsPage />
                    </Route>
                    <Route path="/create-event">
                      <CreateEventPage />
                    </Route>
                    <Route path="/edit-event">
                      <EditTrainerEvent />
                    </Route>
                    <Route path="/leaderboard">
                      <UserLeaderboard />
                    </Route>
                    <Route path="/SportsCenterList">
                      <SportsCenterList />
                    </Route>
                    <Route path="/SportsCenterProfile">
                      <SportsCenterProfile />
                    </Route>
                    <Route path="/edit-challenge">
                      <EditChallenge />
                    </Route>
                    <Route path="/create-challenge">
                      <CreateChallenge />
                    </Route>
                    <Route path='/my-challenges'>
                      <MyChallanges />
                    </Route>
                    <Route path="/challenges">
                      <ChallengesPage />
                    </Route>
                    <Route path="/sports-center-login">
                      <LoginAdmin />
                    </Route>
                    <Route path="/sports-center-register">
                      <RegisterAdmin />
                    </Route>
                    <Route path="/register">
                      <RegisterUser />
                    </Route>
                    <Route path="/profile">
                      <UserProfile />
                    </Route>
                    <Route path="/login">
                      <LoginUser />
                    </Route>
                    <Route path="/trainer-dashboard">
                      <TrainerDashboard />
                    </Route>
                    <Route path="/activity-page/:id">
                      <ActivityPage />
                    </Route>
                    <Route path="/add-activity">
                      <Activity />
                    </Route>
                    <Route path="/">
                      <HomePage />
                    </Route>
                  </Switch>
                </Router>
                <Footer />
              </div>

            </div>
          </SideBarContext.Provider>
        </LanguageContext.Provider>
      </IntlProvider>
    </div>
  );
}

export default App;