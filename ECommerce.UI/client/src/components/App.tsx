import { useEffect, useState } from "react";
import { IProduct } from "../model/IProduct";
import Header from "./Header";
import ProductList from "./ProductList";


function App() {
  const [products, setproducts] = useState<IProduct[]>([]);

  useEffect(() => {
    fetch("http://localhost:7139/api/products")
      .then(response => response.json())
      .then(data => setproducts(data));
  }, []);

  function addProduct() {
    console.log("butona basıldı");
    setproducts([
      ...products,
      {
        id: Date.now(),
        name: "Urun 2",
        price: 32423,
        isActive: true,
      },
    ]);
  }

  return (
    <>
      <h1>React.js</h1>
      <Header products={products} />
      <ProductList products={products} addProduct={addProduct} />
    </>
  );
}

export default App;
