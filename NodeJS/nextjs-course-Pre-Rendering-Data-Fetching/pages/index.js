import { Inter } from 'next/font/google'
import styles from '@/styles/Home.module.css'
import fs from 'fs/promises';
import path from 'path';
import Link from 'next/link';
import Head from 'next/head';

const inter = Inter({ subsets: ['latin'] });

export async function getStaticProps() {
  console.log('(Re-)Generating...')
  const filePath = path.join(process.cwd(), 'data', 'dummy-data.json');
  const jsonData = await fs.readFile(filePath);
  const data = JSON.parse(jsonData);

  if(!data){
    return {
      redirect: {
      destination: '/no-data'
      },
    };
  }

  return { props: {
    Products: data.products
}, revalidate: 10 //not needed for server side rendering
 };
}

export default function Home(props) {
  const { Products } = props;

  return (
    <>
    <Head>
      <title>Pre-Rendering & Data Fetching</title>
      <meta name='description' content='this is for practicing the NExtJS Framework' />
    </Head>
      <ul>
        {Products.map((product) => (
          <li key={product.id}><Link href={`/products/${product.id}`}>{product.title}</Link></li>
        ))}
      </ul>
    </>
  )
}
