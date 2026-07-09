# CountriesClient

This project was generated using [Angular CLI](https://github.com/angular/angular-cli) version 22.0.5.

## Development server

To start a local development server, run:

```bash
ng serve
```

Once the server is running, open your browser and navigate to `http://localhost:4200/`. The application will automatically reload whenever you modify any of the source files.

## Code scaffolding

Angular CLI includes powerful code scaffolding tools. To generate a new component, run:

```bash
ng generate component component-name
```

For a complete list of available schematics (such as `components`, `directives`, or `pipes`), run:

```bash
ng generate --help
```

## Building

To build the project run:

```bash
ng build
```

This will compile your project and store the build artifacts in the `dist/` directory. By default, the production build optimizes your application for performance and speed.

## Running unit tests

To execute unit tests with the [Vitest](https://vitest.dev/) test runner, use the following command:

```bash
ng test
```

## Running end-to-end tests

For end-to-end (e2e) testing, run:

```bash
ng e2e
```

Angular CLI does not come with an end-to-end testing framework by default. You can choose one that suits your needs.

## Additional Resources

For more information on using the Angular CLI, including detailed command references, visit the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.

## Important Note!

Normally, I know, you can start both projects, Web Api and Angular, together in Visual Studio.
But because Angular gets worked on in VSC, I have changed the package manager from NPM to PNPM (because it is better and faster).

**VS does not recognise PNPM!!**

So, what does this mean?
It basically means you cannot start both projects at the same time in VS, that is all.

What do I do now?
You start the Web Api project in VS, as normal.
Then you start in VSC the Angular project with `pnpm start`

What are the cons and pros of this?
The con is that you just cannot start both projects at the same time in VS.
The good part is, though, you mostly just have to start the Web Api in VS,
and then you can go and work on the frontend as long as you want without needing to restart the whole thing all the time.

The question is, what do you want?
If you want to start both projects in VS, then you have to make sure that Angular is using NPM again.
If not, then you only have to stop the Web Api project for if you add code there, and further you can let it keep running,
so you can easily just work on the Angualr project without worrying about the Web Api. 
