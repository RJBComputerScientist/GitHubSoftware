import Image from 'next/image';
import classes from './hero.module.css';
function Hero() {
    return <section className={classes.hero}>
        <div className={classes.image}>
            <Image src={"/images/site/PictureOfMe.jpg"} alt='An image showing me' width={300} height={300} />
        </div>
        <h1>Hi, I'm Ryan</h1>
        <p>I blog about web development, NodeJS, React, AngularJS</p>
    </section>
}

export default Hero;