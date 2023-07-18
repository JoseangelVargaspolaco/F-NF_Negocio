import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

class Validation_Idea {

    private static final String[] QUESTIONS = {
            "¿Tienes un plan de negocios?",
            "¿Cuentas con el capital necesario?",
            "¿Existe demanda para tu producto/servicio?",
            "¿Conoces bien el mercado y la competencia?",
            "¿Tienes habilidades y experiencia relevantes?",
            "¿Tienes una estrategia de marketing sólida?",
            "¿Tienes un equipo calificado?"
    };

    private static final String[] ANSWERS = {
            "Sí",
            "No",
            "No sé"
    };

    private static final int QUESTION_COUNT = QUESTIONS.length;
    private static final int MAX_OPTIONS = 3;

    private int currentQuestionIndex;
    private boolean feasible;
    private List<String> questionResponses;

    // Constructor
    public Validation_Idea() {
        currentQuestionIndex = 0;
        feasible = true;
        questionResponses = new ArrayList<>();
    }

    //Starts the validation process
    public void Inicio() {
        Scanner scanner = new Scanner(System.in);

        for (int i = 0; i < QUESTION_COUNT; i++) {
            // Clear the screen
            LimpiarPantalla();
            // Print the question
            System.out.println(QUESTIONS[i]);
            // Print the possible answers
            for (int j = 0; j < ANSWERS.length; j++) {
                System.out.println((j + 1) + ". " + ANSWERS[j]);
            }
            // Get the user's answer
            int answer = scanner.nextInt();
            // Validate the user's answer
            while (answer < 1 || answer > MAX_OPTIONS) {
                LimpiarPantalla();
                System.out.println(QUESTIONS[i]);
                for (int j = 0; j < ANSWERS.length; j++) {
                    System.out.println((j + 1) + ". " + ANSWERS[j]);
                }
                System.out.print("Tu respuesta: ");
                answer = scanner.nextInt();
            }
            // Add the user's answer to the list of responses
            questionResponses.add(ANSWERS[answer - 1]);
            // If the answer is "No", set the feasible flag to false
            if (answer == 2) {
                feasible = false;
            }
        }

        // Clear the screen
        LimpiarPantalla();
        // Print the table of questions and responses
        System.out.println("Tabla de preguntas y respuestas:");
        System.out.println("--------------------------------\n");
        for (int i = 0; i < QUESTION_COUNT; i++) {
            System.out.println((i + 1) + ". " + QUESTIONS[i] + ": " + questionResponses.get(i));
        }

        // Print the conclusion
        if (!feasible) {
            System.out.println("\n - Deducción: El negocio no es factible.\n");
        } else {
            System.out.println("\n - Deducción: El negocio es factible.\n");
        }
    }

    //Clears the screen
    private void LimpiarPantalla() {
        System.out.print("\033[H\033[2J");
        System.out.flush();
    }

    public static void main(String[] args) {
        Validation_Idea vl = new Validation_Idea();
        vl.Inicio();
    }

}
