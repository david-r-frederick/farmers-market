/**
 * This is intended to be a basic starting point for linting in your app.
 * It relies on recommended configs out of the box for simplicity, but you can
 * and should modify this configuration to best suit your team's needs.
 */

/** @type {import('eslint').Linter.Config} */
module.exports = {
  root: true,
  parserOptions: {
    ecmaVersion: "latest",
    sourceType: "module",
    ecmaFeatures: {
      jsx: true,
    },
  },
  env: {
    browser: true,
    commonjs: true,
    es6: true,
  },
  ignorePatterns: ["!**/.server", "!**/.client"],

  // Base config
  extends: ["eslint:recommended"],

  overrides: [
    // React
    {
      files: ["**/*.{js,jsx,ts,tsx}"],
      plugins: ["react", "jsx-a11y"],
      extends: [
        "plugin:react/recommended",
        "plugin:react/jsx-runtime",
        "plugin:react-hooks/recommended",
        "plugin:jsx-a11y/recommended",
      ],
      settings: {
        react: {
          version: "detect",
        },
        formComponents: ["Form"],
        linkComponents: [
          { name: "Link", linkAttribute: "to" },
          { name: "NavLink", linkAttribute: "to" },
        ],
        "import/resolver": {
          typescript: {},
        },
      },
      rules: {
        /******* Import Specific *******/
        "import/extensions": "off",
        "import/named": "off",
        "import/no-extraneous-dependencies": "off",
        "import/prefer-default-export": "off",
        /******* React Specific *******/
        "react-hooks/exhaustive-deps": "off",
        "react/jsx-filename-extension": ["warn", { "extensions": [".js", ".jsx", ".ts", ".tsx"] }],
        "react/jsx-max-props-per-line": ["warn", { "maximum": { "single": 2, "multi": 1 } }],
        "react/prop-types": "off",
        "react/self-closing-comp": ["warn", { "component": true, "html": false }],
        "react/no-array-index-key": "error",
        "react/no-children-prop": "error",
        "react/no-danger-with-children": "error",
        /******* Typescript ES-Line Specific *******/
        // Justification for 'warn': Sometimes it's required, work to not use these kinds of types, allow comment overrides
        "@typescript-eslint/ban-types": ["warn", {
          "types": {
            "String": true,
            "Boolean": true,
            "Number": false,
            "Symbol": true,
            "{}": false,
            "Object": false,
            "object": false,
            "Function": false
          },
          "extendDefaults": true
        }],
        // Justification for 'off': It's required in several cases and don't want to comment ignore a comment ignore
        "@typescript-eslint/ban-ts-comment": "off",
        // Justification for 'off': It's required for our code in several places. May be able to deep review at a later date
        "@typescript-eslint/consistent-type-definitions": "off",
        "@typescript-eslint/explicit-module-boundary-types": "error",
        // TODO: Clear other warnings before re-enabling this rule
        "@typescript-eslint/no-explicit-any": "off",
        // Justification: often conflicts with no-mixed-operators
        "@typescript-eslint/no-extra-parens": "off",
        // TODO: Clean up other issues before re-enabling this rule for cleanup
        "@typescript-eslint/no-inferrable-types": "off",
        "@typescript-eslint/no-shadow": "error",
        "@typescript-eslint/no-empty-interface": "error",
        "@typescript-eslint/no-empty-function": "error",
        // Justification: sometimes this is required so the transpiler can differentiate between generics and JSX
        "@typescript-eslint/no-unnecessary-type-constraint": "off",
        "@typescript-eslint/no-var-requires": "error",
        /******* Possible Problems *******/
        "array-callback-return": ["error", { "allowImplicit": false, "checkForEach": false }],
        "constructor-super": "error",
        "for-direction": "error",
        "getter-return": "error",
        "no-async-promise-executor": "error",
        // Justification for 'warn': Requires reworking several loops, allowing comment overrides of warnings for now
        "no-await-in-loop": "warn",
        "no-class-assign": "error",
        "no-compare-neg-zero": "error",
        "no-cond-assign": "error",
        "no-const-assign": "error",
        "no-constant-binary-expression": "error",
        "no-constant-condition": "error",
        "no-constructor-return": "error",
        "no-control-regex": "error",
        "no-debugger": "error",
        "no-dupe-args": "error",
        "no-dupe-class-members": "error",
        "no-dupe-else-if": "error",
        "no-dupe-keys": "error",
        "no-duplicate-case": "error",
        "no-duplicate-imports": "error",
        "no-empty-character-class": "error",
        "no-empty-pattern": "error",
        "no-ex-assign": "error",
        "no-fallthrough": "error",
        "no-func-assign": "error",
        "no-import-assign": "error",
        "no-inner-declarations": "error",
        "no-invalid-regexp": "error",
        "no-irregular-whitespace": "error",
        "no-loss-of-precision": "error",
        "no-misleading-character-class": "error",
        "no-new-symbol": "error",
        "no-obj-calls": "error",
        "no-promise-executor-return": "error",
        "no-prototype-builtins": "error",
        "no-self-assign": "error",
        "no-self-compare": "error",
        "no-setter-return": "error",
        "no-sparse-arrays": "error",
        "no-template-curly-in-string": "error",
        "no-this-before-super": "error",
        // Justificiation for 'warn': There are some odd examples where it thinks the types are undefined when they aren't. Allowing comment overrides until that is figured out
        "no-undef": "warn",
        "no-unexpected-multiline": "error",
        "react/no-unescaped-entities": 0,
        "no-unmodified-loop-condition": "error",
        "no-unreachable": "error",
        "no-unreachable-loop": "error",
        "no-unsafe-finally": "error",
        "no-unsafe-negation": "error",
        "no-unsafe-optional-chaining": "error",
        // Justification for 'off': Private members may be used inside separated templates.
        // TODO: This was common in AngJS, but may not be for React. Do a deeper review
        "no-unused-private-class-members": "warn",
        // Justification for 'warn': There are a lot of stubs in code right now
        "no-unused-vars": "warn",
        "no-use-before-define": "error",
        "no-useless-backreference": "error",
        "require-atomic-updates": "error",
        "use-isnan": "error",
        "valid-typeof": "error",
        // Suggestions
        "accessor-pairs": "error",
        // Justification for 'off': Unable to comply with multiple style requirements in the interpreter
        "arrow-body-style": ["off"],
        "block-scoped-var": "error",
        "camelcase": "error",
        // Justification for 'off': This rule is silly and pointless.
        "capitalized-comments": "off",
        // Justification for 'off': Found several classes that are functionally static but used through the system as instances. Need to deeply review transitioning to static
        "class-methods-use-this": "off",
        "complexity": ["error", 50],
        "consistent-return": "error",
        "consistent-this": "error",
        "curly": "error",
        "default-case": "error",
        "default-case-last": "error",
        "default-param-last": "error",
        "dot-notation": "error",
        "eqeqeq": "error",
        "func-name-matching": "error",
        "func-names": "error",
        // Justification for 'off': Disabling until we have a more thorough rule to use globally
        "func-style": "off",
        "grouped-accessor-pairs": "error",
        "guard-for-in": "error",
        "id-denylist": "error",
        // Justification for 'off': Allow single character variable/prop/func/etc names which we use commonly in arrow functions
        // TODO: Make this error but provide an exceptions list to the config of the rule
        "id-length": "off",
        "id-match": "error",
        "init-declarations": "error",
        // Justification for 'warn': We have many files with multiple classes currently
        // TODO: Refactor those extra classes to separated files and then change this rule to error
        "max-classes-per-file": ["warn", 1],
        "max-depth": "error",
        // Justification for 'off': We have lots of files that are super long to handle complex logic, this is fine
        "max-lines": "off",
        // Justification for 'off': Would require a thorough review to fix all instances
        "max-lines-per-function": ["off", 300],
        "max-nested-callbacks": "error",
        "max-params": ["error", 6],
        // Justification for 'off': Would require a thorough review to fix all instances
        "max-statements": ["warn", { "max": 60 }, {"ignoreTopLevelFunctions": true }],
        // Justification for 'off': We handle comments in multiple ways that this rule cannot account for
        "multiline-comment-style": "off",
        // Justification for 'off': Because of how the cvApi is generated. TODO: Refactor to first level lowercase to restore this rule
        "new-cap": "off",
        "no-alert": "error",
        "no-array-constructor": "error",
        "no-bitwise": "error",
        "no-caller": "error",
        "no-case-declarations": "error",
        "no-confusing-arrow": ["error", { "onlyOneSimpleParam": true }],
        "no-console": "off",
        // Justification for 'off': JG *really* doesn't like this rule
        "no-continue": "off",
        "no-delete-var": "error",
        "no-div-regex": "error",
        "no-else-return": "error",
        "no-empty": "error",
        "no-empty-function": "error",
        "no-eq-null": "error",
        "no-eval": "error",
        "no-extend-native": "error",
        "no-extra-bind": "error",
        // Justification for 'off': JSX and falsy conversion don't get along, so explicit
        // boolean casting is often necessary
        "no-extra-boolean-cast": "off",
        "no-extra-label": "error",
        "no-extra-semi": "error",
        "no-floating-decimal": "error",
        "no-global-assign": "error",
        "no-implicit-coercion": "error",
        "no-implicit-globals": "error",
        "no-implied-eval": "error",
        "no-inline-comments": "error",
        "no-invalid-this": "error",
        "no-iterator": "error",
        "no-label-var": "error",
        "no-labels": "error",
        "no-lone-blocks": "error",
        "no-lonely-if": "error",
        "no-loop-func": "error",
        // Justification for 'off': Would require a thorough review to fix all instances
        "no-magic-numbers": "off",
        "no-mixed-operators": ["error", {
          "groups": [
            ["+", "-", "*", "/", "%", "**"],
            ["&", "|", "^", "~", "<<", ">>", ">>>"],
            ["==", "!=", "===", "!==", ">", ">=", "<", "<="],
            // ["?:", "||"],
            ["in", "instanceof"]
          ],
          "allowSamePrecedence": true
        }],
        "no-multi-assign": "error",
        "no-multi-str": "error",
        // Justification for 'off': Sometimes needed for early-outs to reduce nesting
        "no-negated-condition": "off",
        // Justification for 'off': This is fine if properly indented, which other rules enforce
        "no-nested-ternary": "off",
        "no-new": "error",
        "no-new-func": "error",
        "no-new-object": "error",
        "no-new-wrappers": "error",
        "no-nonoctal-decimal-escape": "error",
        "no-octal": "error",
        "no-octal-escape": "error",
        "no-param-reassign": "error",
        "no-plusplus": ["error", { "allowForLoopAfterthoughts": true }],
        "no-proto": "error",
        "no-redeclare": "error",
        "no-regex-spaces": "error",
        "no-restricted-exports": "error",
        "no-restricted-globals": "error",
        "no-restricted-imports": "error",
        "no-restricted-properties": "error",
        "no-restricted-syntax": "error",
        "no-return-assign": "error",
        "no-return-await": "error",
        "no-script-url": "error",
        "no-sequences": "error",
        "no-shadow": "off", // See @typescript-eslint/no-shadow
        "no-shadow-restricted-names": "error",
        "no-ternary": "off", // Justification: We use this normally
        "no-throw-literal": "error",
        // Justification for 'off': Conflicts with 'init-declarations' rule in scenarios where a variable
        // will be initialized in some conditional logic and no starting value makes sense
        "no-undef-init": "off",
        "no-undefined": "off", // TODO: Fix other warnings first
        "no-underscore-dangle": "error",
        "no-unneeded-ternary": "error",
        "no-unused-expressions": "error",
        "no-unused-labels": "error",
        "no-useless-call": "error",
        "no-useless-catch": "error",
        "no-useless-computed-key": "error",
        "no-useless-concat": "error",
        "no-useless-constructor": "error",
        "no-useless-escape": "error",
        "no-useless-rename": "error",
        "no-useless-return": "error",
        "no-var": "error",
        "no-void": "error",
        // TODO: Requires a deeper review of the syntax to make TODOs valid
        "no-warning-comments": ["off", {
          "terms": [ "todo", "fixme", "bug" ],
          "location": "start"
        }],
        "no-with": "error",
        "object-shorthand": "error",
        "one-var": ["error", "never"],
        "one-var-declaration-per-line": "error",
        "operator-assignment": "error",
        "prefer-arrow-callback": "error",
        "prefer-const": "error",
        // Justification for 'off': There are times where destructuring is less readable and it shouldn't be the default.
        "prefer-destructuring": "off",
        "prefer-exponentiation-operator": "error",
        "prefer-named-capture-group": "error",
        "prefer-numeric-literals": "error",
        "prefer-object-has-own": "error",
        "prefer-object-spread": "error",
        "prefer-promise-reject-errors": "error",
        "prefer-regex-literals": "error",
        "prefer-rest-params": "error",
        "prefer-spread": "error",
        "prefer-template": "error",
        "quote-props": ["error", "consistent-as-needed"],
        // Justification for 'off': Unlikely to ever parse a non-base-10 integer
        "radix": "off",
        "require-await": "error",
        "require-unicode-regexp": "error",
        "require-yield": "error",
        "sort-imports": ["error", {
          "ignoreCase": true,
          "ignoreDeclarationSort": true,
          "ignoreMemberSort": false,
          "memberSyntaxSortOrder": [
            "none",
            "all",
            "multiple",
            "single"
          ],
          "allowSeparatedGroups": false
        }],
        // Justification for 'off': It is frequently not intuitive to sort alphabetically for every single object
        "sort-keys": "off",
        "sort-vars": "warn",
        "spaced-comment": ["error", "always", { "exceptions": ["-", "+"] }],
        "strict": "error",
        "symbol-description": "error",
        "vars-on-top": "error",
        "yoda": "error",
        // Layout & Formatting
        "array-bracket-newline": "error",
        "array-bracket-spacing": ["error","always"],
        "array-element-newline": ["error","consistent", { "minItems": 3, "multiline": true }],
        // Justification for 'off': Unable to comply with multiple style requirements in the interpreter
        "arrow-parens": ["off"],
        "arrow-spacing": "error",
        "block-spacing": "error",
        "brace-style": "error",
        // Justification for 'off': "dangling" commas make for cleaner diffs when making edits
        "comma-dangle": "off",
        "comma-spacing": "error",
        "comma-style": "error",
        "computed-property-spacing": "error",
        "dot-location": "off",
        "eol-last": "error",
        "func-call-spacing": "error",
        "function-call-argument-newline": ["error", "consistent"],
        "function-paren-newline": ["error", "multiline-arguments"],
        "generator-star-spacing": "error",
        "implicit-arrow-linebreak": "error",
        "indent": ["error", 2, {
          "SwitchCase": 1,
          "VariableDeclarator": 1,
          "MemberExpression": 1,
          "FunctionDeclaration": { "body": 1, "parameters": 2 },
          "StaticBlock": { "body": 1 },
          "CallExpression": { "arguments": 1 },
          "ArrayExpression": 1,
          "ObjectExpression": 1,
          "ImportDeclaration": 1,
          "flatTernaryExpressions": false,
          "offsetTernaryExpressions": false,
          "ignoreComments": false
        }],
        "jsx-quotes": "error",
        "key-spacing": "error",
        "keyword-spacing": "error",
        "line-comment-position": "error",
        "lines-around-comment": ["error", {
          "beforeBlockComment": false,
          "afterBlockComment": false,
          "beforeLineComment": false,
          "afterLineComment": false,
          "allowBlockStart": true,
          "allowBlockEnd": true,
          "allowObjectStart": true,
          "allowObjectEnd": true,
          "allowArrayStart": true,
          "allowArrayEnd": true,
          "allowClassStart": true,
          "allowClassEnd": true
        }],
        "lines-between-class-members": "error",
        "max-len": ["warn", 120],
        "max-statements-per-line": ["error", { "max": 1 }],
        "multiline-ternary": ["off"], // We regularly switch between single and multiline based on length, other rules accomodate that better
        "new-parens": "error",
        "newline-per-chained-call": "error",
        // See @typescript-eslint/no-extra-parens which doesn't create a false positive on type casts
        "no-extra-parens": ["off"],
        "no-mixed-spaces-and-tabs": "error",
        "no-multi-spaces": "error",
        "no-multiple-empty-lines": ["error", { "max": 1, "maxBOF": 0, "maxEOF": 0 }],
        "no-tabs": "error",
        "no-trailing-spaces": "error",
        "no-whitespace-before-property": "error",
        "nonblock-statement-body-position": "error",
        "object-curly-newline": "error",
        "object-curly-spacing": ["error", "always"],
        "object-property-newline": ["error", {
          "allowAllPropertiesOnSameLine": true
        }],
        "operator-linebreak": ["error", "before"],
        "padded-blocks": ["error", "never"],
        "padding-line-between-statements": "error",
        "quotes": "error",
        "rest-spread-spacing": "error",
        "semi": "error",
        "semi-spacing": "error",
        "semi-style": "error",
        "space-before-blocks": "error",
        "space-before-function-paren": ["error", { "anonymous": "always", "named": "never", "asyncArrow": "always" }],
        "space-in-parens": "error",
        "space-infix-ops": "error",
        "space-unary-ops": "error",
        "switch-colon-spacing": "error",
        "template-curly-spacing": "error",
        "template-tag-spacing": "error",
        "unicode-bom": "off", // No way to correct the bad BOMs currently
        "wrap-iife": "error",
        "wrap-regex": "error",
        "yield-star-spacing": "error"
      },
    },

    // Typescript
    {
      files: ["**/*.{ts,tsx}"],
      plugins: ["@typescript-eslint", "import"],
      parser: "@typescript-eslint/parser",
      settings: {
        "import/internal-regex": "^~/",
        "import/resolver": {
          node: {
            extensions: [".ts", ".tsx"],
          },
          typescript: {
            alwaysTryTypes: true,
          },
        },
      },
      extends: [
        "plugin:@typescript-eslint/recommended",
        "plugin:import/recommended",
        "plugin:import/typescript",
      ],
    },

    // Node
    {
      files: [".eslintrc.cjs"],
      env: {
        node: true,
      },
    },
  ],
};
