import { createBrowserRouter, Navigate } from "react-router";
import App from "../components/App";
import HomePage from "../features/HomePage";
import AboutPages from "../features/AboutPages";
import ContactPage from "../features/ContactPage";
import CatalogPage from "../features/catalog/CatalogPage";
import ProductDetailsPage from "../features/catalog/ProductDetails";
import ErrorPage from "../features/catalog/ErrorPage";
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import ShoppingCardPage from "../features/cart/ShoppingCardPage";
import LoginPage from "../features/account/loginPage";
import RegisterPage from "../features/account/registerPage";

export const router = createBrowserRouter([
    {
        path:"/",
        element:<App></App>,
        children:[
            { path:"",element: <HomePage></HomePage>},
            { path:"about",element: <AboutPages></AboutPages>},
            { path:"contact",element: <ContactPage></ContactPage>},
            { path:"catalog",element: <CatalogPage></CatalogPage>},
            { path:"card",element: <ShoppingCardPage></ShoppingCardPage>},
            { path:"catalog/:id",element: <ProductDetailsPage></ProductDetailsPage>},
            { path:"login",element: <LoginPage></LoginPage>},
            { path:"register",element: <RegisterPage></RegisterPage>},
            { path:"error",element: <ErrorPage></ErrorPage>},
            { path:"server-error",element: <ServerError></ServerError>},
            { path:"not-found",element: <NotFound></NotFound>},
            { path:"*",element:<Navigate to="/not-found"></Navigate> }
        ]
    }
])