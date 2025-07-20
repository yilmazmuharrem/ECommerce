import { useEffect, useState } from "react";
import { IProduct } from "../../model/IProduct";
import ProductList from "./ProductList";
import { CircularProgress } from "@mui/material";
import request from "../../api/request";

export default function CatalogPage(){

  const [products, setproducts] = useState<IProduct[]>([]);
    const [loading, setLoading] = useState(true)

  useEffect(() => {
    request.Catalog.list()
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