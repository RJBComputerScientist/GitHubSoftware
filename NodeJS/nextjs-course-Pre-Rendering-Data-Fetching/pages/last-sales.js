import { useEffect, useState } from "react";

function LastSalesPages(props) {
  const [sales, setSales] = useState(props.sales);
  //                               ^^^^ from "getStaticProps" or "getServerProps". Which is used
  const [isLoading, setLoading] = useState(false);
  useEffect(() => {
    setLoading(true);
    fetch() //url
      .then((response) => response.json())
      .then((data) => {
        const transformedData = [];

        for (const key in data) {
          transformedData.push({
            id: key,
            username: data[key].username,
            volume: data[key].volume,
          });
        }

        setSales();
        setLoading(false);
      });
  }, []);

  if (isLoading) {
    <p>Loading...</p>
  }

  if (!sales) {
    <p>No Data Yet...</p>
  }
  return (
    <ul>
      {sales.map((sale) => (
        <li key={sale.id}>
          {sale.username} - ${sale.volume}
        </li>
      ))}
    </ul>
  );
}
//combining pre-fetching and client-side fetching
export async function getStaticProps(context) {
 return fetch() //url
  .then((response) => response.json())
  .then((data) => {
    const transformedData = [];

    for (const key in data) {
      transformedData.push({
        id: key,
        username: data[key].username,
        volume: data[key].volume,
      });
    }

    return {
      props: {sales: transformedData},
      revalidate: 10
    }
  });
}

export default LastSalesPages;
