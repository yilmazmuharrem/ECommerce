import { createBrowserRouter } from "react-router";
import App from "../components/App";
import HomePage from "../pages/HomePage";
import AboutPages from "../pages/AboutPages";
import ContactPage from "../pages/ContactPage";
import CatalogPage from "../pages/catalog/CatalogPage";
import ProductDetailsPage from "../pages/catalog/ProductDetails";

export const router = createBrowserRouter([
    {
        path:"/",
        element:<App></App>,
        children:[
            { path:"",element: <HomePage></HomePage>},
            { path:"about",element: <AboutPages></AboutPages>},
            { path:"contact",element: <ContactPage></ContactPage>},
            { path:"catalog",element: <CatalogPage></CatalogPage>},
            { path:"catalog/:id",element: <ProductDetailsPage></ProductDetailsPage>},
        ]
    }
])