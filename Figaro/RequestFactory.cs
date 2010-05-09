namespace Figaro {

    public interface RequestFactory {

        Request NewRequest(HttpFixture Fixture);
    }
}