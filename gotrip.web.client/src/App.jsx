
import './App.css';
import { HashRouter, Route, Switch } from 'react-router-dom';
import ResponsiveAppBar from './components/ResponsiveAppBar.js/ResponsiveAppBar';
import Login from './components/Login/Login';

function App() {



   

    return (
        <div className="App">
            <HashRouter>
                <ResponsiveAppBar></ResponsiveAppBar>
                <Switch>
                    <Route path={'/Login'}>
                        <Login></Login>
                    </Route>
                </Switch>
            </HashRouter>
        </div>
    );
    

}

export default App;