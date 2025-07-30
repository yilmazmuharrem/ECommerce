import { createBrowserRouter, Navigate } from "react-router";
import App from "../components/App";
import HomePage from "../pages/HomePage";
import AboutPages from "../pages/AboutPages";
import ContactPage from "../pages/ContactPage";
import CatalogPage from "../pages/catalog/CatalogPage";
import ProductDetailsPage from "../pages/catalog/ProductDetails";
import ErrorPage from "../pages/catalog/ErrorPage";
import ServerError from "../errors/ServerError";
import NotFound from "../errors/NotFound";
import ShoppingCardPage from "../pages/card/ShoppingCardPage";

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
            { path:"error",element: <ErrorPage></ErrorPage>},
            { path:"server-error",element: <ServerError></ServerError>},
            { path:"not-found",element: <NotFound></NotFound>},
            { path:"*",element:<Navigate to="/not-found"></Navigate> }
        ]
    }
])