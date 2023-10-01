import { Inter } from 'next/font/google'
import styles from '@/styles/Home.module.css'
import fs from 'fs/promises';
import path from 'path';
import Link from 'next/link';

const inter = Inter({ subsets: ['latin'] });

export async function getStaticProps() {
  console.log('(Re-)Generating...')
  const filePath = path.join(process.cwd(), 'data', 'dummy-data.json');
  const jsonData = await fs.readFile(filePath);
  const data = JSON.parse(jsonData);

  return { props: {
    Products: data.products
}, revalidate: 10
 };
}

export default function Home(props) {
  const { Products } = props;

  return (
    <>
      <ul>
        {Products.map((product) => (
          <li key={product.id}><Link href={`/${product.id}`}>{product.title}</Link></li>
        ))}
      </ul>
    </>
  )
}
