import { Fragment } from "react";
import fs from 'fs/promises';
import path from 'path';

function productDetails(props) {
    const { loadedProduct } = props;

    if(!loadedProduct){
        return <p>loading...</p>
    }
    //^^^ Performs like a loading screen

    return <Fragment>
        <h1>{loadedProduct.title}</h1>
        <p>{loadedProduct.description}</p>
    </Fragment>
};

async function GetData() {
  const filePath = path.join(process.cwd(), 'data', 'dummy-data.json');
  const jsonData = await fs.readFile(filePath);
  const data = JSON.parse(jsonData);

  return data;
}

export async function getStaticProps(context) {
    const { params } = context;
    const productId = params.pid;

    const data = await GetData();

  const product = data.products.find(product => product.id === productId);

  if(!product){
    return {notFound: true}; // uses the 404 file page in the NextJS project
  }

  return {
    props: {
        loadedProduct: product
    }
  }
}

export async function getStaticPaths(){
    const data = await GetData();

    const ids = data.products.map(product => product.id);

    const PathWithParams = ids.map((id) => ({ params: { pid: id }}));
    return {
        paths: PathWithParams,
        fallback: true
        // paths: [ //for pre-generation (pre-fetch)
        //     { params: { pid: 'p1' } },
        //     // { params: { pid: 'p2' } },
        //     // { params: { pid: 'p3' } },
        // ],
        // fallback: true
        //fallback: 'blocking' //waits for page to be ready for loading... This will make the page load longer
    };
}

export default productDetails;