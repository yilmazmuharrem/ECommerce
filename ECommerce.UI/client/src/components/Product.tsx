import { IProduct } from "../model/IProduct";

interface Props{
    product:IProduct
}

export default function Product(props: Props) {
  return (
    <h3>
      {props.product.name} - {props.product.price}
    </h3>
  );
}