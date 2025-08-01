import { TableCell, TableRow } from "@mui/material";
import { useCartContext } from "../../context/CardContext";
import { currencyTRY } from "../../utils/fortmatCurrency";

export default function CardSummary() {
    const { cart } = useCartContext();
    const subTotal = cart?.cartItems.reduce((toplam, item) => toplam + (item.quantity * item.price), 0) ?? 0;
    const tax = subTotal * 0.2;
    const total = subTotal + tax;
    return (
        <>
        <TableRow>
            <TableCell align="right" colSpan={5}>Ara Toplam</TableCell>
            <TableCell align="right">{currencyTRY.format(subTotal)}</TableCell>
        </TableRow>
         <TableRow>
            <TableCell align="right" colSpan={5}>Vergi (%20)</TableCell>
            <TableCell align="right">{currencyTRY.format(tax)}</TableCell>
        </TableRow>
            <TableRow>
            <TableCell align="right" colSpan={5}>Toplam</TableCell>
            <TableCell align="right">{currencyTRY.format(total)}</TableCell>
        </TableRow>
  </>
    );
}