import { IProduct } from "../model/IProduct";
import Product from "./Product";
interface Props{
    products:IProduct[],
    addProduct:()=>void;
}


export default function ProductList({products,addProduct}: Props) {
  return (
    <>
      <h1>Ürünler</h1>
      {products.map((p) =>
        p.isActive ? <Product key={p.id} product={p} /> : null
      )}
      <button onClick={addProduct}>BANA TIKLA</button>
    </>
  );
}