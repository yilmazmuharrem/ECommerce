import { useEffect, useState } from "react";
import { IProduct } from "../../model/IProduct";
import ProductList from "./ProductList";
import { CircularProgress } from "@mui/material";

export default function CatalogPage(){

  const [products, setproducts] = useState<IProduct[]>([]);
    const [loading, setLoading] = useState(true)

  useEffect(() => {
    fetch("http://localhost:7139/api/products")
      .then(response => response.json())
      .then(data => setproducts(data)).
       catch(error=>console.log(error))
       .finally(()=>setLoading(false));

  }, []);
    if(loading) return <CircularProgress></CircularProgress>

    return(
    <>
    
    <ProductList products={products}></ProductList>
    </>
    )
}